    public IList<IMyClass> Foo()
    {
        IList<IMyClass> foo = SomeQuery(); 
    
        var result = foo.GroupBy(x => x.bar)
                        .Select<IGrouping<Foo>, IMyClass>(x => new MyClass())
                        .ToList();
        return result;
    }
