    using System;
    using System.Xml;
    using System.Xml.Serialization;
    public class Person {
        public string Name { get; set; }
    }
    
    static class Program {
        static void Main() {
            Person person = new Person { Name = "Fred"};
            XmlSerializer ser = new XmlSerializer(typeof(Person));
            // write
            using (XmlWriter xw = XmlWriter.Create("file.xml")) {
                ser.Serialize(xw, person);
            }
            // read
            using (XmlReader xr = XmlReader.Create("file.xml")) {
                Person clone = (Person) ser.Deserialize(xr);
                Console.WriteLine(clone.Name);
            }
        }
    }
