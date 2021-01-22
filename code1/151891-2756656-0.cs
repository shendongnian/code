    using System;
    using System.Runtime.Serialization;
    using System.IO;
    [DataContract]
    public class Outer {
        [DataMember]
        public Inner Inner { get; set; }
    }
    [DataContract]
    public class Inner {
        [DataMember]
        public Outer Outer { get; set; }
    }
    class Program {
        static void Main() {
            // make a cyclic graph
            Outer outer = new Outer(), clone;
            outer.Inner = new Inner { Outer = outer };
            
            var dcs = new DataContractSerializer(typeof(Outer), null,
                int.MaxValue, false, true, null);
            using (MemoryStream ms = new MemoryStream()) {
                dcs.WriteObject(ms, outer);
                ms.Position = 0;
                clone = (Outer)dcs.ReadObject(ms);
            }
            Console.WriteLine(ReferenceEquals(
                clone, clone.Inner.Outer)); // true
        }
    }
