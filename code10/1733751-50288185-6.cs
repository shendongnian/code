    using ProtoBuf;
    using System;
    using System.IO;
    
    public abstract class grid { }
    
    [ProtoContract]
    [ProtoInclude(7, typeof(Class_A))]
    [ProtoInclude(8, typeof(Class_B))]
    public class ProtoStub : grid
    {
        [ProtoMember(1)]
        public int RootMember { get; set; }
    }
    
    [ProtoContract]
    public class Class_A : ProtoStub
    {
        [ProtoMember(1)]
        public string DerivedMember { get; set; }
    }
    
    [ProtoContract]
    public class Class_B : ProtoStub
    {
    }
    static class P
    {
        static void Main()
        {
            ProtoStub obj = new Class_A
            {
                RootMember = 123,
                DerivedMember = "abc"
            }, clone;
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, obj);
                ms.Position = 0;
                clone = Serializer.Deserialize<ProtoStub>(ms);
            }
    
            Console.WriteLine(clone.RootMember);
            if(clone is Class_A)
            {
                Class_A typed = (Class_A)clone;
                Console.WriteLine(typed.DerivedMember);
            }
        }
    }
