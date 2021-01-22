    [Something(123)]
    public void GetAllFoosHelper()
    {
      SetupSomething(); 
    }
    
    public IEnumerable<Foo> GetAllFoos() 
    { 
      GetAllFoosHelper();
    
      DataReader dr = RunSomething(); 
      while (dr.Read()) 
      { 
        yield return Factory.Create(dr); 
      } 
    } 
