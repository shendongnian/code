    public void test()
    {
        Type someType = getSomeType(); // get some System.Type object
        Type openType = typeof(MyGeneric<>);
        Type actualType = openType.MakeGenericType(new Type[] { someType });
        object obj = Activator.CreateInstance(actualType);
    }
