    using System;
    using System.Collections.Generic;
    using System.Linq;
                        
    public class Program
    {
        public static void Main()
        {
                var students =
                    new [] {
                        "StudentA, Math, Mrs.Jones, Sixth, 98, 92, 90, , 40",
                        "StudentB, Science, Mrs.Williams, Second, , 91, 70, 50, 41",
                        "StudentC, History, Mr.Webber, Eighth, 100, 92, 90, 75, 40",
                        "StudentD, Art, Mrs.Gonzalez, Fourth, 99, 91, 85,, 40"
                    };
            
            foreach (var student in WithDefaultStudentValues(students))
            {
                Console.WriteLine(student);
            }
        }
        
        public static IEnumerable<string> WithDefaultStudentValues(IEnumerable<string> students)
        {
            foreach (var student in students)
            {
                var studentValues =
                    student
                        .Split(',')
                        .Select(value => string.IsNullOrWhiteSpace(value) ? "0" : value);
            
                yield return string.Join(",", studentValues);
            }
        }
    }
