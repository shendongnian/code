    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using ProtoBuf;
    
    [Serializable, ProtoContract]
    public class Department
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public List<Person> People { get; set; }
    }
    
    [Serializable, ProtoContract]
    public class Person
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public DateTime DateOfBirth { get; set; }
    }
    
    
    static class Program
    {
        [MTAThread]
        static void Main()
        {
            Department dept = new Department { Name = "foo"};
            dept.People = new List<Person>();
            Random rand = new Random(123456);
            for (int i = 0; i < 20000; i++)
            {
                Person person = new Person();
                person.Id = rand.Next(50000);
                person.DateOfBirth = DateTime.Today.AddDays(-rand.Next(2000));
                person.Name = "fixed name";
                dept.People.Add(person);
            }
    
            byte[] raw;
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, dept);
                raw = ms.ToArray(); // 473,399 bytes
            }
    
            XmlSerializer ser = new XmlSerializer(typeof(Department));
            StringWriter sw = new StringWriter();
            ser.Serialize(sw, dept);
            string s = sw.ToString(); // 2,115,693 characters
        }
    }
