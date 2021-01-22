    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    public class MyWrapper {
        //2: [XmlElement("A", Type = typeof(ChildA))]
        //2: [XmlElement("B", Type = typeof(ChildB))]
        //3: [XmlArrayItem("A", Type = typeof(ChildA))]
        //3: [XmlArrayItem("B", Type = typeof(ChildB))]
        public List<ChildClass> Data { get; set; }
    }
    //1: [XmlInclude(typeof(ChildA))]
    //1: [XmlInclude(typeof(ChildB))]
    public abstract class ChildClass {
        public string ChildProp { get; set; }
    }
    public class ChildA : ChildClass {
        public string AProp { get; set; }
    }
    public class ChildB : ChildClass {
        public string BProp { get; set; }
    }
    static class Program {
        static void Main() {
            var ser = new XmlSerializer(typeof(MyWrapper));
            var obj = new MyWrapper {
                Data = new List<ChildClass> {
                    new ChildA { ChildProp = "abc", AProp = "def"},
                    new ChildB { ChildProp = "ghi", BProp = "jkl"}}
            };
            ser.Serialize(Console.Out, obj);
        }
    }
