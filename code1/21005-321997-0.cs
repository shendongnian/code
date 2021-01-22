    using System;
    using System.IO;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    public class Program
    {
        [XmlArrayItem("Property")]
        public List<string> Properties = new List<string>();
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Properties.Add("test1");
            program.Properties.Add("test2");
            program.Properties.Add("test3");
    
            XmlSerializer xser = new XmlSerializer(typeof(Program));
            xser.Serialize(new FileStream("test.xml", FileMode.Create), program);
        }
    }
