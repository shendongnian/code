        Type mytype = typeof (int);
        Type listGenericType = typeof (List<>);
        Type list = listGenericType.MakeGenericType(mytype);
        ConstructorInfo ci = list.GetConstructor(new Type[] {});
        List<int> listInt = (List<int>)ci.Invoke(new object[] {});
