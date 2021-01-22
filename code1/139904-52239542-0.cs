    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TestCase : Attribute
    {
        public TestCase(string value)
        {
            Id = value;
        }
        public string Id { get; }        
    }   
    public static IEnumerable<string> AutomatedTests()
    {
        var assembly = typeof(Reports).GetTypeInfo().Assembly;
        var methodInfos = assembly.GetTypes().SelectMany(m => m.GetMethods())
            .Where(x => x.GetCustomAttributes(typeof(TestCase), false).Length > 0);
        foreach (var methodInfo in methodInfos)
        {
            var ids = methodInfo.GetCustomAttributes<TestCase>().Select(x => x.Id);
            yield return $"{string.Join(", ", ids)} - {methodInfo.Name}"; // handle cases when one test is mapped to multiple test cases.
        }
    }
