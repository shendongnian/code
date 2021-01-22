    public IList<IMyClass> Foo()
    {
        IList<IMyClass> foo = SomeQuery(); 
    
        var result = foo.GroupBy(x => x.bar)
            .Select<IGrouping<IMyClass, Bar>>, IMyClass>(x => new MyClass())
            .ToList();
        return result;
    }
