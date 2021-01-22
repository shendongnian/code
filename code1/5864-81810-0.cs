    [TestMethod]
    public void GetFoo_NotNull_Test_ForFile()
    {   
       GetFoo_NotNull(new FileRepository().GetRepository());
    }
    
    [TestMethod]
    public void GetFoo_NotNull_Test_ForSql()
    {   
       GetFoo_NotNull(new SqlRepository().GetRepository());
    }
    
    
    private void GetFoo_NotNull(IFooRepository repository)
    {
      var results = repository. GetFoo();   
      Assert.IsNotNull(results);
    }
