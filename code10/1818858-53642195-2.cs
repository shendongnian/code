    public IQueryable<MyData> Query(string name) {
      MyDbContext dbc;
      try
      {
         dbc = new MyDbContext();
         return dbc.MyData.Where(v => v.Name == name);
      }
      finally
      {
         dbc.Dispose();
      }   
    }
