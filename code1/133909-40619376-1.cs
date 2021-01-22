    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class GenericTestCaseAttribute : TestCaseAttribute, ITestBuilder
    {
        private readonly Type _type;
        public GenericTestCaseAttribute(Type type, params object[] arguments) : base(arguments)
        {
            _type = type;
        }
        IEnumerable<TestMethod> ITestBuilder.BuildFrom(IMethodInfo method, Test suite)
        {
            if (method.IsGenericMethodDefinition && _type != null)
            {
                var gm = method.MakeGenericMethod(_type);
                return BuildFrom(gm, suite);
            }
            return BuildFrom(method, suite);
        }
    }
