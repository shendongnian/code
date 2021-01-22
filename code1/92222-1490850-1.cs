    using System;
    using System.Xml.Serialization;
    public class MyData
    {
        [XmlAttribute]
        public int Id { get; set; }
        public string Name { get; set; }
    
        static void Main()
        {
            var obj = new MyData { Id = 1, Name = "Fred" };
    
            XmlAttributeOverrides config1 = new XmlAttributeOverrides();
            config1.Add(typeof(MyData),"Name",
                new XmlAttributes { XmlIgnore = true});
            var ser1 = new XmlSerializer(typeof(MyData),config1); 
            ser1.Serialize(Console.Out, obj);
            Console.WriteLine();
            Console.WriteLine();
            XmlAttributeOverrides config2 = new XmlAttributeOverrides();
            config2.Add(typeof(MyData), "Name",
                new XmlAttributes { XmlIgnore = false });
            var ser2 = new XmlSerializer(typeof(MyData), config2);
            ser2.Serialize(Console.Out, obj);
        }
    }
