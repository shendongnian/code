    [ProtoContract]
    [ProtoInclude(1, typeof(Foo)]
    [ProtoInclude(2, typeof(Bar)]
    public class OuterMessage { ... }
    [ProtoContract]
    public class Foo : OuterMessage {}
    [ProtoContract]
    public class Bar : OuterMessage {}
