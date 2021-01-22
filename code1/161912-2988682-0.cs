        using System.Collections.Generic;
        using System.IO;
        using System.Xml;
        using System.Xml.Serialization;
        public class Student {
            [XmlElement("id")]
            public int id;
            [XmlElement("name")]
            public string name;
        }
        [XmlRoot("students")]
        public class Students {
            [XmlElement("students")]
            public List<Student> students = new List<Student>();
        }
        class Program {
            static void Main(string[] args) {
                Students s = new Students();
                s.students.Add(new Student() { id = 1, name = "John Doe" });
                s.students.Add(new Student() { id = 2, name = "Jane Doe" });
                XmlSerializer xs = new XmlSerializer(typeof(Students));
                using (FileStream fs = new FileStream("students.xml", FileMode.Create, FileAccess.Write)) {
                    xs.Serialize(fs, s);
                }
            }
        }
