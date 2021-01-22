    public class Foo
    {
        static readonly ICollection<string> g_collection;
        // Static constructor
        static Foo()
        {
            g_collection = new List<string>();
            g_collection.Add("Hello");
            g_collection.Add("World!");
        }
    }
