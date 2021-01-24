    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication100
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.csv";
    		static void Main(string[] args)
    		{
                Person person = new Person(FILENAME);
                person.Sort();
    		}
     
        }
        public class Person : IComparable 
        {
            public string Name { get;set;}
            public int Age { get;set;}
            public DateTime DOB { get;set;}
            public string sex { get;set;}
            List<Person> dataCollection = new List<Person>();
            public Person() { }
            public Person(string filename)
            {            
                using (var f = new StreamReader(filename))
                {
                    string line = string.Empty;
                    int rowCount = 0;
                    while ((line = f.ReadLine()) != null)
                    {
                        if (++rowCount > 1)
                        {
                            var data = line.Split(',');
                            dataCollection.Add(new Person() { Name = data[0], Age = Convert.ToInt32(data[1]), DOB = Convert.ToDateTime(data[2]), sex = data[3]});
                        }
                    }
                }
            }
            public int CompareTo(object obj)
            {
                return this.DOB.CompareTo(((Person)obj).DOB);
            }
            public void Sort()
            {
                dataCollection.Sort();
            }
        }
    }
