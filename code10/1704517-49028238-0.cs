    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication25
    {
        class Program
        {
           static void Main(string[] args)
            {
               XElement xml = new XElement("People", Person.people.Select(x => new XElement("Name", new object[] { new XAttribute("foo", x.attribute), x.value})));
            }
        }
        public class Person
        {
            public static List<Person> people = new List<Person>();
            public string Name { get; set; }
            public string attribute { get; set; }
            public string value { get; set; }
        }
    }
