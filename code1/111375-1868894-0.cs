    public class AImplementation : IAInterface
    {
       void AInterfaceMethod()
       {
       }
    
       void AnotherMethod()
       {
          this.AInterfaceMethod();
       }
    }
