    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class GenericTestCaseAttribute : TestCaseAttribute, ITestBuilder
    {
        public GenericTestCaseAttribute(params object[] arguments)
            : base(arguments)
        {
        }
        IEnumerable<TestMethod> ITestBuilder.BuildFrom(IMethodInfo method, Test suite)
        {
            if (!method.IsGenericMethodDefinition) return base.BuildFrom(method, suite);
            var numberOfGenericArguments = method.GetGenericArguments().Length;
            var typeArguments = Arguments.Take(numberOfGenericArguments).OfType<Type>().ToArray();
            if (typeArguments.Length != numberOfGenericArguments)
            {
                var parms = new TestCaseParameters { RunState = RunState.NotRunnable };
                parms.Properties.Set("_SKIPREASON", $"Arguments should have {typeArguments} type elements");
                return new[] { new NUnitTestCaseBuilder().BuildTestMethod(method, suite, parms) };
            }
            var genMethod = method.MakeGenericMethod(typeArguments);
            return new TestCaseAttribute(Arguments.Skip(numberOfGenericArguments).ToArray()).BuildFrom(genMethod, suite);
        }
    }
