    public IEnumerable<Foo> GetFoosByParent(FooParent parent)
    {
        return GetFooChildrenByParentID(parent.ID))
               .Select(f => ObjectFactories.FooFactory(f));
    }
