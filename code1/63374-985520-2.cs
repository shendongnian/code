    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    [XmlRoot("response")]
    public class MyResponse {
        public MyResponse() {
            Entries = new List<Entry>();
        }
        [XmlElement("startIndex", Order = 1)]
        public int StartIndex { get; set; }
        [XmlElement("entry", Order = 2)]
        public List<Entry> Entries { get; set; }
    }
    public class Entry {
        public Entry() { }
        public Entry(Person person) { Person = person; }
        [XmlElement("person")]
        public Person Person { get; set; }
        public static implicit operator Entry(Person person) {
            return person == null ? null : new Entry(person);
        }
        public static implicit operator Person(Entry entry) {
            return entry == null ? null : entry.Person;
        }
    }
    public class Person {
        [XmlElement("name")]
        public string Name { get; set; }
    }
    static class Program {
        static void Main() {
            MyResponse resp = new MyResponse();
            resp.StartIndex = 1;
            resp.Entries.Add(new Person { Name = "meeee" });
            resp.Entries.Add(new Person { Name = "youuu" });
            XmlSerializer ser = new XmlSerializer(resp.GetType());
            ser.Serialize(Console.Out, resp);
        }
    }
