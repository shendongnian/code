    using System;
    using ProtoBuf;
    [ProtoContract]
    class Foo {
        static void Main() {
            Foo foo = new Foo { Bar = MyEnum.B };
            Console.WriteLine(foo.Bar);
            Foo clone = Serializer.DeepClone(foo);
            Console.WriteLine(clone.Bar); // Expect "B"
        }
    
        [ProtoMember(1)]
        public MyEnum Bar { get; set; }
    }
    enum MyEnum { A, B, C }
