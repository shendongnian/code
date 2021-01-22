    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    static class Program
    {
        static readonly XmlSerializer ser;
        static Program()
        {
            List<Type> extraTypes = new List<Type>();
            // TODO: read config, or use reflection to
            // look at all assemblies
            extraTypes.Add(typeof(Bar));
            ser = new XmlSerializer(typeof(Foo), extraTypes.ToArray());
        }
        static void Main()
        {
            Foo foo = new Bar();
            MemoryStream ms = new MemoryStream();
            ser.Serialize(ms, foo);
            ms.Position = 0;
            Foo clone = (Foo)ser.Deserialize(ms);
            Console.WriteLine(clone.GetType());
        }
    }
    
    public abstract class Foo { }
    public class Bar : Foo {}
