    var list = session
        .CreateCriteria(typeof (Employee))
        .SetProjection(Projections
                       .ProjectionList()
                       .Add(Projections.Property("Id"), "Id")
                       .Add(Projections.Property("FName"), "FirstName")
                       .Add(Projections.Property("LName"), "LastName"))
        .SetResultTransformer(Transformers.AliasToBean<Employee>())
        .List<Employee>();
