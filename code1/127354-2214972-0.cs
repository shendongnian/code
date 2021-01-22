    public bool DuplicateUsername()
    {
        var spec = MyIocContainer.Resolve<DuplicateUsernameSpecification>();
        return spec.IsSatisfiedBy(this);
    }
