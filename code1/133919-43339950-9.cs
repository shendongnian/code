    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TestCaseSourceGenericAttribute : TestCaseSourceAttribute, ITestBuilder
    {
        public TestCaseSourceGenericAttribute(string sourceName)
            : base(sourceName)
        {
        }
        public Type[] TypeArguments { get; set; }
        IEnumerable<TestMethod> ITestBuilder.BuildFrom(IMethodInfo method, Test suite)
        {
            if (!method.IsGenericMethodDefinition)
                return base.BuildFrom(method, suite);
            if (TypeArguments == null || TypeArguments.Length != method.GetGenericArguments().Length)
            {
                var parms = new TestCaseParameters { RunState = RunState.NotRunnable };
                parms.Properties.Set("_SKIPREASON", $"{nameof(TypeArguments)} should have {method.GetGenericArguments().Length} elements");
                return new[] { new NUnitTestCaseBuilder().BuildTestMethod(method, suite, parms) };
            }
            var genMethod = method.MakeGenericMethod(TypeArguments);
            return base.BuildFrom(genMethod, suite);
        }
    }
