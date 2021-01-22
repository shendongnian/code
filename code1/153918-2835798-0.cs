    Expression.Eq(
      Projections.SqlProjection("({alias}." + propertyname + " & " + 
        ((int)value).ToString() + ") as " + propertyname + "Result",
        new[] { propertyname + "Result" },
        new IType[] { NHibernateUtil.Int32 }
      ), value );
