    public IQueryable<MyData> Query(string name) {
      MyDbContext dbc;
      dbc = new MyDbContext();
      try
      {&#xD;
         return dbc.MyData.Where(v => v.Name == name);
      }
      finally
      {
         dbc.Dispose();
      }   
    }
