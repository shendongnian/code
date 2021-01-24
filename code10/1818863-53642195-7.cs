    public IQueryable<MyData> Query(MyDbContext dbc, string name) {
         return dbc.MyData.Where(v => v.Name == name);
    }
    public f() { 
      using(var dbc = new MyDbContext())
      {
          var res = Query(dbc, "john").Select(v => ......
          var resList = res.ToList();
          ...
      }      
    }
