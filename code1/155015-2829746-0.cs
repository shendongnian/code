    class LargeClass
    {
    public void DoProcess()
    {
      if (DoProcess1())
      {
        if (DoProcess2())
        {
          DoProcess3();
        }
      }
    }
    
    protected bool DoProcess1()
    {
    ...
    }
    
    protected bool DoProcess2()
    {
    ...
    }
    
    protected bool DoProcess3()
    {
    ...
    }
    
    }
