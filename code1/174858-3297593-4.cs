    public IList<IMyClass> Foo()
    {
        IList<IMyClass> foo = SomeQuery(); 
        var result = foo.GroupBy(x => x.bar)
                        .Select(x => new MyClass())
                        .Cast<IMyClass>()
                        .ToList();
        return result;
    }
