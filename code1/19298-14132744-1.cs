    void Foo(IConvertible o)
    {
        switch (o.GetTypeCode)
        {
            case TypeCode.Int16:
            case TypeCode.Int32:
            //etc ......
        }
    }
