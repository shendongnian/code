    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;
    
    [DataContract, KnownType(typeof(Building))]
    abstract class Node {
        [DataMember]
        public int Foo {get;set;}
    }
    [DataContract]
    class Building : Node {
        [DataMember]
        public string Bar {get;set;}
    }
    
    static class Program
    {
        static void Main()
        {
            Dictionary<Guid, Node> data = new Dictionary<Guid, Node>();
            Type type = typeof(Dictionary<Guid, Node>);
            data.Add(Guid.NewGuid(), new Building { Foo = 1, Bar = "a" });
            StringWriter sw = new StringWriter();
            using (XmlWriter xw = XmlWriter.Create(sw))
            {
                DataContractSerializer dcs = new DataContractSerializer(type);
                dcs.WriteObject(xw, data);
            }
    
            string xml = sw.ToString();
    
            StringReader sr = new StringReader(xml);
            using (XmlReader xr = XmlReader.Create(sr))
            {
                DataContractSerializer dcs = new DataContractSerializer(type);
                Dictionary<Guid, Node> clone = (Dictionary<Guid, Node>)
                    dcs.ReadObject(xr);
                foreach (KeyValuePair<Guid, Node> pair in clone)
                {
                    Console.WriteLine(pair.Key + ": " + pair.Value.Foo + "/" +
                        ((Building)pair.Value).Bar);
                }
            }
        }
    }
