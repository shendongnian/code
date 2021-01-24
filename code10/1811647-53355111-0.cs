    public class TestMethodWithConditionAttribute : TestMethodAttribute
    {
        public Type ConditionParentType { get; set; }
        public string ConditionPropertyName { get; set; }
        public TestMethodWithConditionAttribute(string conditionPropertyName, Type conditionParentType)
        {
            ConditionPropertyName = conditionPropertyName;
            ConditionParentType = conditionParentType;
        }
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            if (ConditionParentType.GetProperty(ConditionPropertyName, BindingFlags.Static | BindingFlags.Public)?.GetValue(null) is bool condiiton && condiiton)
            {
                return base.Execute(testMethod);
            }
            else
            {
                return new TestResult[] { new TestResult {  Outcome = UnitTestOutcome.Inconclusive } };
            }
        }
    }
