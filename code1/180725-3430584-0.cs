    using Core.Service.X;
    using Core.Service.Y;
    
    public class A //without injection
    {
      private ServiceX servicex;
      private ServiceY servicey;
    
      public A ()
      {
        servicex = new ServiceX();
        servicey = new ServiceY();
      }
    }
