    void Foo(object o)
    {
        switch (Type.GetTypeCode(o.GetType())) // for IConvertible, just o.GetTypeCode()
        {
            case TypeCode.Int16:
            case TypeCode.Int32:
            //etc ......
        }
    }
