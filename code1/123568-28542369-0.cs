    [TestClass]
    [DeploymentItem(TestParams.ConfigFileName)]
    public class MyTest
    {
    	public static class TestParams
    	{
    		public const string ConfigFileName = "TestConfig.xml";
    	}
    // ...
    }
