    using System;
    using System.IO;
    using System.Runtime.Serialization;
    
    [DataContract]
    class Node {
        [DataMember]
        public Node AnotherNode { get; set; }
    }
    
    static class Program
    {
        static void Main()
        {
            Node a = new Node(), b = new Node();
            // make it a cyclic graph, to prove reference-mode
            a.AnotherNode = b;
            b.AnotherNode = a;
    
            // the preserveObjectReferences argument is the interesting one here...
            DataContractSerializer dcs = new DataContractSerializer(
                typeof(Node), null, int.MaxValue, false, true, null);
            using (MemoryStream ms = new MemoryStream())
            {
                dcs.WriteObject(ms, a);
                ms.Position = 0;
                Node c = (Node) dcs.ReadObject(ms);
                // so .AnotherNode.Another node should be back to "c"
                Console.WriteLine(ReferenceEquals(c, c.AnotherNode.AnotherNode));
            }
    
        }
    }
