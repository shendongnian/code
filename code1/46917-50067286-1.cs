    Public BaseClass
    {
      public string test{ get; set;}
    }
    public Derived : BaseClass
    {
    //Some properies
    }
    
    public void CopyProps()
    {
       BaseClass baseCl =new BaseClass();
       baseCl.test="Hello";
       Derived drv=new Derived();
       drv.CopyOnlyEqualProperties(baseCl);
       //Should return Hello to the console now in derived class.
       Console.WriteLine(drv.test);
    }
