    class MyIEnumerable
    { }
    class MyICollection : MyIEnumerable
    { }
    class MyIQueryable : MyIEnumerable
    { }
    private void MethodWithMyIQueryable(MyIQueryable someObj)
    { }
    
    private void DoSth()
    {
        //valid
        MethodWithMyIQueryable(new MyIQueryable());
        //invalid
        MethodWithMyIQueryable(new MyICollection());
    }
