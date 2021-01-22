    using System;
    using System.Xml.Serialization;
    public class MyData
    {
        [XmlAttribute]
        public int Id { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlIgnore]
        public bool NameSpecified { get; set; }
    
        static void Main()
        {
            var ser = new XmlSerializer(typeof(MyData));
    
            var obj1 = new MyData { Id = 1, Name = "Fred", NameSpecified = true };
            ser.Serialize(Console.Out, obj1);
            Console.WriteLine();
            Console.WriteLine();
            var obj2 = new MyData { Id = 2, Name = "Fred", NameSpecified = false };
            ser.Serialize(Console.Out, obj2);
        }
    }
