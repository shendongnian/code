    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace SerializationSample
    {
        class Program
        {
            private const string STR_CtempSerilizationxml = @"c:\temp\Serilization.xml";
            static void Main(string[] args)
            {
                Foo foo = new Foo(Guid.NewGuid().ToString());
                Console.WriteLine("Foo.Id = " + foo.Id);
    
                SerializeToFile(foo, STR_CtempSerilizationxml);
    
                Foo fooDeserialized = DeserializeFromFile(STR_CtempSerilizationxml);
    
                Console.WriteLine("Foo.Id = " + fooDeserialized.Id);
                
            }
    
            private static void SerializeToFile(Foo foo, string sFilespec)
            {
                XmlSerializer iSerializer = new XmlSerializer(typeof(Boo));
                using (FileStream stream = new FileStream(sFilespec, FileMode.Create))
                {
                    iSerializer.Serialize(stream, new Boo(foo));
                }
            }
    
            public static Foo DeserializeFromFile(string sFilespec)
            {
                XmlSerializer oSerializer = new XmlSerializer(typeof(Boo));
                using (System.IO.FileStream oStream = new FileStream(sFilespec, FileMode.Open))
                {
                    return new Foo(((Boo)oSerializer.Deserialize(oStream)).Id);
                }
            }
        }
    
        public class Foo
        {
            private readonly string _Id;
            public string Id 
            { 
                get { return _Id; }
            }
            public Foo(string id) { Id = id; }      
        }
    
        public class Boo
        {
            public string Id { get; set; }
            
            public Boo(Foo foo) { Id = foo.Id; }
    
            public Boo() { }
        }
    }
