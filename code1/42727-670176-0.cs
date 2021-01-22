    using System;
    using System.Runtime.Serialization;
    using System.Xml;
    
    class Program {
        static void Main() {
            using (XmlWriter writer = XmlWriter.Create(Console.Out)) {
                new DataContractSerializer(typeof(Foo))
                    .WriteObject(writer, new Foo());
            }       
        }
    }
    
    [DataContract]
    partial class Foo {
        [DataMember(Name="Bar")]
        private int? bar;
        public int Bar {
            get {
                if (bar == null) bar = 27; // somthing lazy
                return bar.GetValueOrDefault();
            }
            set { bar = value; }
        }
    }
    /* UNCOMMENT THIS
    partial class Foo {
        [OnSerializing]
        private void BeforeSerialize(StreamingContext ctx) {
            int tmp = Bar;
        }
    }
    */
