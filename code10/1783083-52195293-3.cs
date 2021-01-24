    public class SutProvider 
    {
        public static ATypeController GetATypeController() => new ATypeController(GetProxy(), GetATypeControllerLogger());
        public static IProxy GetProxy() {
            // Either return a valid IProxy, or set up a mock that can return a result from the GetProxy method that is valid enough to withstand InstitutionAddressProcessor's constructor.
        }
        public static ILogger<ATypeController> GetATypeControllerLogger() => new Mock<ILogger<ATypeController>>().Object;
    }
