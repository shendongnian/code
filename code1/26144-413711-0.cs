    public class Foo
    {
        private static readonly ICollection<string> g_collection = initializeCollection();
    
        private static ICollection<string> initializeCollection()
        {
            ... TODO allocate and return something here ...
        }
    }
