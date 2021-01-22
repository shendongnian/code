    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System;
    [XmlRoot("response")]
    public class MyCollection
    {
        [XmlElement("person", Type = typeof(Person)), Order = 2]
        public List<ItemBase> entry;
        [XmlElement(Order = 1)]
        public int startIndex;
    }
    public abstract class ItemBase { }
    public class Person : ItemBase
    {
        public string name;
    }
    
    static class Program
    {
        static void Main()
        {
            MyCollection c = new MyCollection();
            c.entry = new List<ItemBase>();
            c.entry.Add(new Person { name = "meeee" });
            c.entry.Add(new Person { name = "youuu" });
            XmlSerializer ser = new XmlSerializer(c.GetType());
            ser.Serialize(Console.Out, c);
        }
    }
