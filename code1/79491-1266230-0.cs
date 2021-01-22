    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;
    using System.Xml;
    namespace TestXmlSerialiser
    {
        public class Person
        {
            public string Name;
        }
        class Program
        {
            static void Main(string[] args)
            {
                Person person = new Person();
                person.Name = "Jack & Jill";
                XmlSerializer ser = new XmlSerializer(typeof(Person));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(Console.Out, settings))
                {
                    ser.Serialize(writer, person);
                }
            }
        }
    }
