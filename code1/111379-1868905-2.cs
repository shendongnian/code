    public class AImplementation : IAInterface
    {
        IAInterface IAInterface;
        public AImplementation() {
            IAInterface = (IAInterface)this;
        }
        void IAInterface.AInterfaceMethod()
        {
        }
        void AnotherMethod()
        {
           IAInterface.AInterfaceMethod();
        }
    }
