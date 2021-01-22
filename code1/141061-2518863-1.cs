    public void SomeMethod()
    {
       Type[] interfaces = typeof(Foo).GetInterfaces();
       Debug.Assert(interfaces.Contains(typeof(IEnumerable<int>)));
    }
