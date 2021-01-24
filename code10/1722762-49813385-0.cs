    public MyView()
    {
      var query = GetAllSchoolsAsync();
      query.Wait();
      _initialCollection = query.Result;      
    }
