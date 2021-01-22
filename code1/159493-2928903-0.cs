    using System;
    using System.Xml.Serialization;
    public class Data
    {
        public int Foo { get; set; }
        [Obsolete] public int Bar {get;set;}
    
        static void Main()
        {
            var data = new Data { Foo = 1, Bar = 2 };
            new XmlSerializer(data.GetType()).Serialize(Console.Out, data);
        }
    }
