    #if MOCK
    //only registered if inside MOCK build type.
    [assembly: PreApplicationStartMethod(typeof(MockInitializer), "Initialize")]
    namespace MChatServer.MockBuild
    {
        public class MockInitializer
        {
            public static void Initialize()
            {
                //Inject all the mocked dependencies through mocked service factory
                global.serviceFactory = new ServiceFactoryMock();
            }
        }
    ...
    }
    #end
