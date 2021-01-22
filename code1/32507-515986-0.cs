    using System;
    using System.Xml.Serialization;
    [Serializable] public class Foo { }
    [Serializable] public class Bar : Foo {}
    
    static class Program {
        static void Main()
        {
            XmlSerializer ser = new XmlSerializer(typeof(Foo),
                new Type[] { typeof(Bar) });
            ser.Serialize(Console.Out, new Bar());
        }
    }
