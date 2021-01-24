    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Globalization;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                
                Course c1 = new Course{
                    cName = "Course 1",
                    Start_Time = "10:00",
                    End_Time = "10:50",
                    Days = new List<string>{ "Mon", "Tue", "Wed"}
                };
                
                Course c2 = new Course{
                    cName = "Course 2",
                    Start_Time = "10:40",
                    End_Time = "11:20",
                    Days = new List<string>{ "Wed", "Thu", "Fri"}
                };
                
                Course c3 = new Course{
                    cName = "Course 3",
                    Start_Time = "11:30",
                    End_Time = "12:20",
                    Days = new List<string>{ "Mon", "Tue", "Fri"}
                };
                
                
                bool areC1C2Clashing = areCoursesClashing(c1, c2);
                Console.WriteLine("Are c1 & c2 clashing - " + areC1C2Clashing);
                Console.WriteLine();
                
                bool areC2C3Clashing = areCoursesClashing(c2, c3);
                Console.WriteLine("Are c2 & c3 clashing - " + areC2C3Clashing);
                Console.WriteLine();
                
                bool areC1C3Clashing = areCoursesClashing(c1, c3);
                Console.WriteLine("Are c1 & c3 clashing - " + areC1C3Clashing);
                Console.WriteLine();
            }
            
            public static bool areCoursesClashing(Course cA, Course cB){
                bool clashDetected = false;
                foreach(var coruseDay in cA.Days){
                    if(cB.Days.Contains(coruseDay)){
                        
                        DateTime cAStartTime = DateTime.ParseExact(cA.Start_Time, "HH:mm", CultureInfo.InvariantCulture);
                        DateTime cAEndTime = DateTime.ParseExact(cA.End_Time, "HH:mm", CultureInfo.InvariantCulture);
                        DateTime cBStartTime = DateTime.ParseExact(cB.Start_Time, "HH:mm", CultureInfo.InvariantCulture);
                        DateTime cBEndTime = DateTime.ParseExact(cB.End_Time, "HH:mm", CultureInfo.InvariantCulture);
                        
                        if( cAStartTime < cBEndTime && cBStartTime < cAEndTime){
                            Console.WriteLine("WARNING!!! Classes clash for --> " + cA.cName + " & " + cB.cName);
                            clashDetected = true;
                        }
                    }
                }
                return clashDetected;
            }
        }
        
        public class Course {
            public string cName { get; set; }
            public string Start_Time { get; set; }
            public string End_Time { get; set; }
            public List<string> Days { get; set; }
        }
    }
