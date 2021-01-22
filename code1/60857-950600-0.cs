    using System;
    using System.IO;
    using System.Threading;
    using ProtoBuf;
    
    [ProtoContract]
    class Foo {
        static int count;
        public static int ObjectCount { get { return count; } }
        public Foo() { // track how many objects have been created...
            Interlocked.Increment(ref count);
        }
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public double Bar { get; set; }    
    }
    static class Program {
        static void Main() {
            MemoryStream ms = new MemoryStream();
            Random rand = new Random();
            for (int i = 1; i <= 5000; i++) {
                Foo foo = new Foo { Bar = rand.NextDouble(), Id = i };
                Serializer.SerializeWithLengthPrefix(ms, foo,PrefixStyle.Base128, 1);
            }
            ms.Position = 0;
            // skip 1000
            int index = 0;
            object obj;
            Console.WriteLine(Foo.ObjectCount);
            Serializer.NonGeneric.TryDeserializeWithLengthPrefix(
                ms, PrefixStyle.Base128,
                tag => ++index == 1000 ? typeof(Foo) : null, out obj);
            Console.WriteLine(Foo.ObjectCount);
            Console.WriteLine(((Foo)obj).Id);
        }
    }
