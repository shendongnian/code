    public IList<IMyClass> Foo()
    {
        IList<IMyClass> foo = SomeQuery(); 
        var result = foo.GroupBy(x => x.bar)
                        .Select(x => (IMyClass) new MyClass())
                        .ToList();
        return result;
    }
