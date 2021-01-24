    public class TestMethodForConfigAttribute : TestMethodAttribute
    {
        public string Name { get; set; }
        public TestMethodForConfigAttribute(string name)
        {
            Name = name;
        }
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            if (IsConfigEnabled(Name))
            {
                return base.Execute(testMethod);
            }
            else
            {
                return new TestResult[] { new TestResult {  Outcome = UnitTestOutcome.Inconclusive } };
            }
        }
        public static bool IsConfigEnabled(string name)
        {
            //...
            return false;
        }
    }
