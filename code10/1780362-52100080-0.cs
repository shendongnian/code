    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    
    namespace Stackoverflow_Konsole_Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                string CSV_FILE_PATH = @"filepath.csv";
    
                List<string> FULL_CSV_STRING = new List<string>();
                Students Student1 = new Students();
    
                FULL_CSV_STRING.Add(File.ReadAllText(CSV_FILE_PATH));
    
                foreach (string line in FULL_CSV_STRING)
                {
                    Student1.add(line);               
                }
    
                foreach (string line in Student1.getlist())
                {
                    Console.WriteLine(line);
                }
                Console.ReadLine();
            }
        }
    }
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Stackoverflow_Konsole_Test
    {
        class Students
        {
            private List<string> List_of_students = new List<string>();
    
    
            public Students()
            {
                //constructor
            }
    
            public void add(string line)
            {
                this.List_of_students.Add(line);
            }         
            public List<string> getlist()
            {
                return this.List_of_students;
            }
        }
    }
