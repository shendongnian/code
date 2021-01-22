    public class Foo&lt;T&gt; 
        where T : new()
    {
        static Expression&lt;Func&lt;T&gt;&gt; x = () => new T();
        static Func&lt;T&gt; f = x.Compile();
        public static T build()
        {
            return f();
        }
    }
