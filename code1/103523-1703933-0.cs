    Session.CreateCriteria<ClassX>()    
           .CreateAlias("ListY", "y")
           .CreateAlias("y.Z", "z")
           .Add(Expression.Eq("z.Id", 2))
           .List<ClassX>();
    
    Session.CreateCriteria<ClassX>()    
           .CreateAlias("ListY", "y")
           .Add(Expression.Eq("y.Z.Id", 2))
           .List<ClassX>();
