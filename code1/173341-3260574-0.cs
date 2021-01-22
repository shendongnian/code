    public override U GetUniqueIdentifier()
    {
        var generator = _container.Resolve<IUIDGenerator<U>>();
        return generator.Create();
    }
