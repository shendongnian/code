    class MyObject { public byte[] Result { get; set;} }
    context.MyTable.Select(e => new MyObject
    { 
        Result = CustomDbFunctions.IsNull(e.myBinary, e.myFloat)
    });
