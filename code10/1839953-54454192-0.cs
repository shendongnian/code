    struct MyStruct {
       public Guid g;
    }
    ...
    var s = new MyStruct();
    var span = new Span<byte>(s.g.ToByteArray());
    span[2] = 4;
