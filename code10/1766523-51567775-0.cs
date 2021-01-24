    public static class TestHelperExtensions
    {
        public static ITestProvider TestProvider { get; set; }
        public static string Get(this ITestHelper html, string arg)
        {
            return TestProvider.Get(arg);
        }
    }
