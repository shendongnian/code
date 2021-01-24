    public class ApiTestsBase
    {
        protected static Lazy<string> TokenLazy = new Lazy<string>(() =>
                                                                 {
                                                                     // Log in and get your API token
                                                                     Console.WriteLine("Logging into API to get token. You should only see this message on the first test that runs"); 
                                                                     return "DEADBEEF";
                                                                 });
        
    }
    [TestFixture]
    public class EndpointATests : ApiTestsBase
    {
        private string GetResultFromEndPoint()
        {
            // Call endpoint with token from TokenLazy.Value
            Console.WriteLine($"Calling EndpointA with token {TokenLazy.Value}");
            return "PayloadA";
        }
        [Test]
        public void Test1()
        {
            var payload = this.GetResultFromEndPoint();
            // Assert things about payload
        }
    }
    [TestFixture]
    public class EndpointBTests : ApiTestsBase
    {
        private string GetResultFromEndPoint()
        {
            // Call endpoint with token from TokenLazy.Value
            Console.WriteLine($"Calling EndpointB with token {TokenLazy.Value}");
            return "PayloadB";
        }
        [Test]
        public void Test1()
        {
            var payload = this.GetResultFromEndPoint();
            // Assert things about payload
        }
    }
