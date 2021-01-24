    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Solutions
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Student> students = new List<Student>()
                                             {
                                                 new Student(){BaseId = 100, FName = "A", Id = 1, LName = "Z", Name = "A Z", Scores = "90", StudentId = 1},
                                                 new Student(){BaseId = 100, FName = "A", Id = 2, LName = "Z", Name = "A Z", Scores = "10", StudentId = 1},
                                                 new Student(){BaseId = 100, FName = "A", Id = 3, LName = "Z", Name = "A Z", Scores = "10", StudentId = 1},
                                                 new Student(){BaseId = 100, FName = "B", Id = 2, LName = "Y", Name = "B Y", Scores = "91", StudentId = 2},
                                                 new Student(){BaseId = 100, FName = "C", Id = 3, LName = "X", Name = "C X", Scores = "92", StudentId = 3},
                                                 new Student(){BaseId = 100, FName = "D", Id = 4, LName = "W", Name = "D W", Scores = "93", StudentId = 4},
                                                 new Student(){BaseId = 100, FName = "E", Id = 5, LName = "V", Name = "E V", Scores = "91", StudentId = 5},
                                             };
    
                // Total Score Select and Order By in the end for sorting
                var totalScoresSelect = students.GroupBy(student => student.StudentId).Select(
                    groupedStudent => new
                    {
                        StudentId = groupedStudent.Key,
                        TotalScore = groupedStudent.Sum(student => long.Parse(student.Scores)),
                        groupedStudent.First().FName,
                        groupedStudent.First().LName,
                        groupedStudent.First().Name
                    }).OrderBy(totalScore => totalScore.TotalScore);
    
                foreach (var totalScore in totalScoresSelect)
                {
                    Console.WriteLine(totalScore.StudentId);
                    Console.WriteLine(totalScore.FName);
                    Console.WriteLine(totalScore.LName);
                    Console.WriteLine(totalScore.Name);
                    Console.WriteLine(totalScore.TotalScore);
                }
    
                Console.ReadLine();
            }
        }
    }
