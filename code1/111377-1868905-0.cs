    public class AImplementation : IAInterface
    {
        IAInterface _thisAInterface;
        public AImplementation() {
            _thisAInterface = (IAInterface)this;
        }
        void IAInterface.AInterfaceMethod()
        {
        }
        void AnotherMethod()
        {
           _thisAInterface.AInterfaceMethod();
        }
    }
