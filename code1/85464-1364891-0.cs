    using System.Collections.Generic;
    using ProtoBuf;
    
    [ProtoContract]
    [ProtoInclude(20, typeof(SomeDerived))]
    public class SomeBase
    {
        [ProtoMember(1)]
        public string BaseProp { get; set; }
    }
    [ProtoContract]
    public class SomeDerived : SomeBase
    {
        [ProtoMember(1)]
        public int DerivedProp { get; set; }
    }
    [ProtoContract]
    public class SomeEntity
    {
        [ProtoMember(1)]
        public List<SomeBase> SomeList;
    }
    
    class Program
    {
        static void Main()
        {
            SomeEntity orig = new SomeEntity
            {
                SomeList = new List<SomeBase> {
                    new SomeBase { BaseProp = "abc"},
                    new SomeDerived { BaseProp = "def", DerivedProp = 123}
                }
            };
            var clone = Serializer.DeepClone(orig);
            // clone now has a list with 2 items, one each SomeBase and SomeDerived
        }
    }
