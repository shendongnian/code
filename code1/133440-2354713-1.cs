    using System;
    using System.IO;
    using System.Xml.Serialization;
    [XmlRoot("ClassA")]
    public class ClassA {
        [XmlElement]
        public String TextA {
            get;
            set;
        }
    }
    [XmlRoot("ClassA")] // note that the two are the same
    public class ClassB : ClassA {
        [XmlElement]
        public String TextB {
            get;
            set;
        }
    }
    class Program {
        static void Main(string[] args) {
            // create a ClassA object and serialize it
            ClassA a = new ClassA();
            a.TextA = "some text";
            // serialize
            XmlSerializer xsa = new XmlSerializer(typeof(ClassA));
            StringWriter sw = new StringWriter();
            xsa.Serialize(sw, a);
            // deserialize to a ClassB object
            XmlSerializer xsb = new XmlSerializer(typeof(ClassB));
            StringReader sr = new StringReader(sw.GetStringBuilder().ToString());
            ClassB b = (ClassB)xsb.Deserialize(sr);
        }
    }
