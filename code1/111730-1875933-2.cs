    public DetachedCriteria GetCriteria()
    {
        return DetachedCriteria.For<Entity>()
            .Add(Restrictions.Eq(...))
            .Add(...);
    }
