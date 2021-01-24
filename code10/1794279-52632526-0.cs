    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication71
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<Personal> personals = doc.Descendants("record").Select(x => new Personal()
                {
                    ID = (string)x.Element("ID"),
                    Name = (string)x.Element("Name"),
                    Email = (string)x.Element("Email"),
                    DateOfBirth = (DateTime)x.Element("DateOfBirth"),
                    Gender = (string)x.Element("Gender"),
                    City = (string)x.Element("City")
                }).ToList();
            }
     
        }
        public class Personal
        {
            public string ID {get ; set; }
            public string Name {get ; set; }
            public string Email {get ; set; }
            public DateTime DateOfBirth {get ; set; }
            public string Gender {get ; set; }
            public string City { get; set; }
        }
    }
