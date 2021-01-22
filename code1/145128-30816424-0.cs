    using(SqlConnection con = new SqlConnection(conStr))
    {
      using(var context1 = new SampleEntities(existingConnection:con, contextOwnsConnection:false)
      {
      }
    
      using(var context2 = new SampleEntities(existingConnection:con, contextOwnsConnection:false)
      {
      }
    }
    
