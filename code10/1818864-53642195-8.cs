    public IQueryable<MyData> Query(string name) {
      MyDbContext dbc;
      dbc = new MyDbContext();
      try
      {
         return dbc.MyData.Where(v => v.Name == name);
      }
      finally
      {
         dbc.Dispose();
      }   
    }
