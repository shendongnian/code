    public abstract class Processor
    {
      // this is the only public method
      // implements the order of the separate steps
      public void Process()
      {
        Step1();
        Step2();
        //... 
      }
      // implementation is provided by derived classes
      protected abstract void Step1();
      protected abstract void Step2();
    }
