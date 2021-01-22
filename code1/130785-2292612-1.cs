    public class NeedsExtension<T>
        {
            public static string DoSomething <T>(this MyType<T> v)
            {   return ""; }
             
            // OR
            public static void DoSomething <T>(this MyType<T> v)
            {   }
        }
