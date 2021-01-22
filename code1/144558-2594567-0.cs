    [Something(123)]
    public IEnumerable<Foo> GetAllFoos()
    {
      SetupSomething();
      List<Foo> results = new List<Foo>();
      DataReader dr = RunSomething();
      while (dr.Read())
      {
        results.Add(Factory.Create(dr));
      }
      return results;
    }
