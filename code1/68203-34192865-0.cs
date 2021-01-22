    object o;
    //...
    Type type = o.GetType();
    PropertyInfo pi = type.GetProperty("Value");
    pi.SetMethod.Invoke(o, new object[] {23});
