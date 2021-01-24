    using System;
    
    namespace Problem
    {
        public class Student
        {
            public bool IsStudent { get; set; }
            public int? Age { get; set; }
            public string Name { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                // GetDefault.
                Student Student_One = GetDefault();
                Console.WriteLine("IsStudent = {0} \nName = {1} \nAge = {2}", Student_One.IsStudent, Student_One.Age, Student_One.Name);
    
                Console.WriteLine("-------------------------");
    
                Student Student_Two = GetDefault();
                Student_Two.Age = 19;
                Student_Two.Name = "Nick";
                Console.WriteLine("IsStudent = {0} \nName = {1} \nAge = {2}", Student_Two.IsStudent, Student_Two.Age, Student_Two.Name);
    
                Console.WriteLine("-------------------------");
    
                Student Student_Three = new Student
                {
                    IsStudent = true,
                    Age = 20,
                    Name = "Johnson"
                };
                Console.WriteLine("Name = {0} & Age = {1}" , Student_Three.Age,  Student_Three.Name);
                Console.WriteLine();
            }
    
            static Student GetDefault()
            {
                Student student = new Student
                {
                    IsStudent = true
                };
    
                return student;
            }
        }
    }
