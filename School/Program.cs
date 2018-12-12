using System;
using System.Collections.Generic;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            Student vivian = new Student("Vivi");
            Student student1 = new Student("Student 1", 4);
            Student student2 = new Student("Student 2", 4);
            student2.AddGrade(3, 4);
            student2.AddGrade(3, 3);

            Console.WriteLine(vivian);
            Console.WriteLine(student1);
            Console.WriteLine(student2);

            // SEE EQUAL() SPECIAL METHOD AND ITS OVERRIDE IN THE STUDENT CLASS
            if (student1.Equals(student2))
            {
                Console.WriteLine("Student 1's ID# " + student1.GetStudentID() + " is the same as student 2's ID# " + student2.GetStudentID() + ".");
            }
            else
            {
                Console.WriteLine("Student 1's ID# " + student1.GetStudentID() + " is not the same as student 2's ID# " + student2.GetStudentID() + ".");
            }

            Console.ReadLine();
        }
    }

    public class Student
        // PROPERTIES
    {
        private static int nextStudentID = 1;
        public string Name { get; set; }
        public int StudentID { get; set; }
        public int NumberOfCredits { get; set; }
        public int NumberOfPoints { get; set; }
        public double GPA
        {
            get
            {
                double gpa = NumberOfPoints / NumberOfCredits;
                // Do a bunch of GPA calculation here
                return gpa;
            }
        }



        // CONSTRUCTOR
        public Student(string name, int studentID, int numberOfCredits, int numberOfPoints)
        {
            Name = name;
            StudentID = studentID;
            NumberOfCredits = numberOfCredits;
            NumberOfPoints = numberOfPoints;
        }

        // CONSTRUCTOR OVERLOADING
        public Student(string name, int studentID)
            : this(name, studentID, 0, 0) { }

        public Student(string name)
            : this(name, nextStudentID)
        {
            nextStudentID++;
        }

        // METHODS

        public override bool Equals(object obj)
        {
            if (obj == this) // safeguards against two objects to compare are the exact same object
            {
                return true;
            }

            if (obj == null) // safeguards against when the object is null
            {
                return false;
            }

            if (obj.GetType() != GetType()) // if (obj.GetType() != this.GetType())
            {
                return false;
            }

            // if true...
            Student studentObj = obj as Student; // casting/converting with the "as" operator
            return StudentID == studentObj.StudentID; // return this.Name == studentObj.Name;
        }

        public override int GetHashCode()
        {
            return StudentID;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetStudentID()
        {
            return StudentID;
        }

        public void AddGrade(int numberOfCredits, int numberOfPoints) // void doesn't return anyting
        {
            // Update the appropriate properties: NumberOfCredits, GPA

            NumberOfCredits += numberOfCredits;
        }

        public void GetGradeLevel() // returns a string via the method procedure
        {
            // Determine the grade level ofthe student based on NumberOfCredits
        }

        public override string ToString()
        {
            return Name + " (Credits: " + NumberOfCredits + ", GPA: " + GPA + ")";
        }
    }

    // readonly (with fields, only get, no set) and constants
    class Course
    {
        public string CourseName { get; set; }
        public int CourseID { get; set; }
        public string Subject { get; set; }
        public string Instructor { get; set; }
        //public List<string> Students = new List<string>(); // Make a list and use student class

        public List<string> Students { get { return _students; } }

        List<string> _students = new List<string>();


        // void means you are not returning anything; in this case, only altering a list
        public void AddStudents()
        {
            // add the students to _students
           
        }
    }
}
