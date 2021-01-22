    public class AImplementation : IAInterface
    {
       public void AInterfaceMethod()
       {
       }
    
       void AnotherMethod()
       {
          this.AInterfaceMethod();
       }
    }
