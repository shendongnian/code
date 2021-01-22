    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    public class Foo
    {
        private List<Bar> bars = new List<Bar>();
        public List<Bar> Bars { get { return bars; } }
    }
    
    public class Bar {
        public string Name { get; set; }
    }
    
    static class Program
    {
        static void Main()
        {
            Foo orig = new Foo { Bars = { new Bar { Name = "abc"},
                new Bar { Name = "def"}}}, clone;
            using(MemoryStream ms = new MemoryStream()) {
                XmlSerializer ser = new XmlSerializer(orig.GetType());
                ser.Serialize(ms, orig);
                ms.Position = 0;
                clone = (Foo)ser.Deserialize(ms);
            }
            clone.Bars.Add(new Bar { Name = "ghi" });
            foreach (Bar bar in clone.Bars)
            {
                Console.WriteLine(bar.Name);
            }
        }
    }
