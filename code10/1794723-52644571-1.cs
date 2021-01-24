    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Student
    {
        public int Id {get;set;}
        public string Name {get;set;}
    }
    
    class Program
    {
        static List<Student> Students {get;set;}
        
        static void Main()
        {
            Students = new List<Student>
            {
                new Student{ Id = 1, Name = "G"},
                new Student{ Id = 2, Name = "D"},
                new Student{ Id = 3, Name = "G"},
                new Student{ Id = 4, Name = "G"},
                new Student{ Id = 5, Name = "D"},
                new Student{ Id = 6, Name = "E"},
                new Student{ Id = 7, Name = "F"},
                new Student{ Id = 8, Name = "G"},
                new Student{ Id = 9, Name = "H"}
            };
            
            WriteStudents(null, null); // 1,2,3,4,5,6,7,8,9
            WriteStudents(null, "D");  // 2,5
            WriteStudents("G", null);  // 1,3,4,8
            WriteStudents("G", "D");   // 1,2,3,4,5,8
        }
        
        static void WriteStudents(string GName, string DName)
        {
            var query = Students.Where(s => string.IsNullOrWhiteSpace(GName)
                                         && string.IsNullOrWhiteSpace(DName)
                                         || s.Name == GName || s.Name == DName)
                                .Select(s => s.Id); // used to print the Id
            
            Console.WriteLine(string.Join(",", query));
        }
    }
