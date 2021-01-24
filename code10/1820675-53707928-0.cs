    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var customDataList = new CustomDataList(); 
                customDataList.AddStudent(); 
                foreach(var element in customDataList.GetList())
                {
                    Console.WriteLine(element);
                }
            }
        }
        
        public class CustomDataList {
            private List<string> students = new List<string>();
            public List<string> GetList()
            {
                return students;
            }
            public void AddStudent()
            {
                students.Add("Morgan");
                students.Add("Loren");
                students.Add("Martin");
                students.Add("Ariana");
                students.Add("Nikkita");
            }
        }    
    }
