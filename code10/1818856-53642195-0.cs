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
    public f() { 
      var res = Query("john").Select(v => ......
      var resList = res.ToList();
      ...
    }
