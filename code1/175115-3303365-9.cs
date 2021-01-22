    public void Command1(B obj)
    {
        object a = Unity.Resolve(typeof(A<>).MakeGenericType(obj.GetType());
        a.GetType().GetMethod("SetObject").Invoke(a, new object[] { obj });
    }
