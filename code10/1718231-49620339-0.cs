    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Root root = new Root() {
                    PersonList = new List<Person>() {
                        new Person() {
                            person = "Person1",
                            child = "Child1"
                        },
                        new Person() {
                            person = "Person2",
                            adult = "Adult2"
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME,settings);
                serializer.Serialize(writer, root);
            }
        }
        public class Root
        {
            [XmlElement("Person")]
            public List<Person> PersonList { get; set; }
        }
        public class Person
        {
            [XmlElement("Person")]
            public string person { get; set; }
            [XmlElement("Child")]
            public string child { get; set; }
            [XmlElement("Adult")]
            public string adult { get; set; }
        }
    }
