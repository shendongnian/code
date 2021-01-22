    public interface IRegistry
    {
        string GetCurrentUserValue(string key);
    }
    public class RegistryReader
    {
        public RegistryReader(IRegistry registry)
        { 
            ...
            // make the dependency explicit in the constructor.
        }
    }
    [TestFixture]
    public class RegistryReaderTests
    {
        [Test]
        public void Foo_test()
        { 
            var stub = new StubRegistry();
            stub.ReturnValue = "known value";
            RegistryReader testedReader = new RegistryReader(stub);
            // test here...
        }
        public class StubRegistry
            : IRegistry
        {
            public string ReturnValue;
            
            public string GetCurrentUserValue(string key)
            {
                return ReturnValue;
            }
        }
    }
