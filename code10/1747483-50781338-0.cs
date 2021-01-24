    public class MyIntegrationTests : IClassFixture<TestServerFixture<Startup>>
    {
        public MyIntegrationTests (TestServerFixture<Startup> testServerFixture, ITestOutputHelper outputHelper)
        {
            client = testServerFixture.Client;
            this.outputHelper = outputHelper;
        }
    }
