    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    [XmlRoot("ROOT")]
    public class MyType
    {
        [XmlElement("ID")]
        public string Id { get; set; }
        [XmlElement("NAME")]
        public string Name { get; set; }
        [XmlElement("STAT")]
        public string Stat { get; set; }
        [XmlElement("TEST")]
        public MyOtherType Nested { get; set; }
    }
    public class MyOtherType
    {
        [XmlElement("ID")]
        public string Id { get; set; }
        [XmlElement("NAME")]
        public string Name { get; set; }
    }
    static class Program
    {
        
        static void Main()
        {
            string xml = @"<ROOT>
                       <ID>1</ID>
                       <NAME>RF1</NAME>
                       <STAT>10200</STAT>
                       <TEST>
                           <ID>1</ID>
                           <NAME>BIGUN</NAME>
                       </TEST>
                       </ROOT>";
            MyType obj = (MyType) new XmlSerializer(typeof(MyType))
                .Deserialize(new StringReader(xml));
            Console.WriteLine(obj.Id);
            Console.WriteLine(obj.Name);
            Console.WriteLine(obj.Stat);
            Console.WriteLine(obj.Nested.Id);
            Console.WriteLine(obj.Nested.Name);
        }
    }
