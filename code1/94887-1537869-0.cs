    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    [XmlRoot("Root")]
    public class MyType
    {
        [XmlElement("Id")]
        public string Id { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
    }
    
    static class Program
    {
        static void Main()
        {
            string xml = @"<Root>
                              <Id>1</Id>
                              <Name>The Name</Name>
                          </Root>";
            MyType obj = (MyType) new XmlSerializer(typeof(MyType))
                .Deserialize(new StringReader(xml));
            Console.WriteLine(obj.Id);
            Console.WriteLine(obj.Name);
        }
    };
