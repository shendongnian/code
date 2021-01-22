    IList<Object[]> list = session.CreateCriteria(typeof(Employee))
      .SetProjection(Projections.ProjectionList()
        .Add(Projections.Property("FirstName"))
        .Add(Projections.Property("LastName"))
      ).List(Object[]);
      
      foreach( Object[] person in list )
      {
        String firstName = person[0];
        String lastName = person[1];
      }
