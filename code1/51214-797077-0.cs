    using System;
    using System.Xml.Serialization;
    [Serializable, XmlRoot("myElement")]
    public class MyType {
        [XmlAttribute("name")]
        public string Name {get;set;}
    
        [XmlText]
        public string Text {get;set;}
    } 
    static class Program {
        static void Main() {
            new XmlSerializer(typeof(MyType)).Serialize(Console.Out,
                new MyType { Name = "foo", Text = "bar" });
        }
    }
