    [ProtoInclude(typeof(Foo), 20)]
    [ProtoInclude(typeof(Bar), 21)]
    public abstract class MyBase {
        /* other members */
        public byte[] GetBytes()
        {
            using(MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize<MyBase>(ms, this); // MyBase can be implicit
                return ms.ToArray();
            }
        }
    }
    [ProtoContract]
    class Foo : MyBase { /* snip */ }
    [ProtoContract]
    class Bar : MyBase { /* snip */ }
