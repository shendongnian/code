    puvlic class Env
    {
         public object Obj{get;set;}
    }
    public object Deser(Stream s)
    {
        var ser = new XmlSerrializer(typeof(Env), [list of known types])
        var env = ser.Deserialize(s);
        var env.Obj;
    }
    public void Test(Stream s)
    {
        var obj = Deser(Stream s);
        // Do your tests here.
        if (obj is SomeType)
    }
