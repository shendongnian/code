    public class TestQuery : ObjectGraphType<object>
    {
        public TestQuery(ITestService testService, IHttpContextAccessor accessor)
        {
            Field<TestResultType>(
                "result",
                description: "Test data",
                resolve: context => testService.GetDetailsForLocation(accessor.HttpContext...)
            );
        }
    }
