    [TestClass]
    [DeploymentItem(TestParams.ConfigFileName)]
    public class MyTest
    {
    	private static class TestParams
    	{
    		public const string ConfigFileName = "TestConfig.xml";
    	}
    // ...
    }
