    public void Command1(B obj)
    {
        object a = (object)new Implementor();
        a.GetType().GetMethod("SetObject").Invoke(a, new object[] { obj });
    }
