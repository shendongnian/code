    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    class A {
        public int Foo { get; set; }
    }
    [Serializable]
    class B : A, ISerializable {
        public string Bar { get; set; }
        public B() { }
    
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("Foo", Foo);
            info.AddValue("Bar", Bar);
        }
        private B(SerializationInfo info, StreamingContext context) {
            Foo = info.GetInt32("Foo");
            Bar = info.GetString("Bar");
        }    
    }
    static class Program {
        static void Main() {
            BinaryFormatter bf = new BinaryFormatter();
            B b = new B { Foo = 123, Bar = "abc" }, clone;
            using (MemoryStream ms = new MemoryStream()) {
                bf.Serialize(ms, b);
                ms.Position = 0;
                clone = (B)bf.Deserialize(ms);
            }
            Console.WriteLine(clone.Foo);
            Console.WriteLine(clone.Bar);
        }
    }
