    static void SomeMethod<T>(T param) where T : BaseB
    {
        dynamic d = param;
        // This will use the execution-time type of param
        var tmp1 = d.SomeProperty;
    }
