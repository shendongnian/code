    public class AandB
    {
      private ClassA _instanceA = new ClassA();
      private ClassB _instanceB = new ClassB();
    
      public bool PropertyA
      {
        get
        {
          return _instanceA.PropertyA;
        }
        set
        {
          _instanceA.PropertyA = value;
        }
      }
    
      public bool PropertyB
      {
        get
        {
          return _instanceB.PropertyB;
        }
        set
        {
          _instanceB.PropertyB = value;
        }
      }
    }
