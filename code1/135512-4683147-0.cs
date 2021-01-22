    public DetachedCriteria BuildMyCriteria()
    {
        var criteria = DetachedCriteria.For<ParentClass>();
        criteria.CreateCriteria("this.ChildClass", "Child Class").SetFetchMode("this.ChildClass", FetchMode.Eager);
        criteria.Add(Restrictions.IsNotNull("ChildClass.Property");      
    
        return criteria;
    }
