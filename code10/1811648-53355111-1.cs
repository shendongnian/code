    [TestClass]
    public class MyTests
    {
        [TestMethodWithCondition(nameof(Configuration.IsMyFeature1Enabled), typeof(Configuration))]
        public void MyTest()
        {
            //...
        }
    }
    public static class Configuration
    {
        public static bool IsMyFeature1Enabled => false;
    }
