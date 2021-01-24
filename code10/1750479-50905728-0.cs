    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    class Program
    {    static void Main()
        {
            var ser = new XmlSerializer(typeof(Parent));
            var obj = new Parent
            {
                Childrens = {
                    new Child { },
                    new SpecialChild { },
                }
            };
            ser.Serialize(Console.Out, obj);
        }
    }
    public class Parent
    {
        [XmlElement("Child", typeof(Child))]
        [XmlElement("SpecialChild", typeof(SpecialChild))]
        public List<Child> Childrens { get; } = new List<Child>();
    }
    public class Child { }
    public class SpecialChild : Child { }
