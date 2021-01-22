    public class NeedsExtension<T>
        {
            public static string NeedsExtension<T>(this MyType<T> v)
            {   return ""; }
             
            // OR
            public static void NeedsExtension<T>(this MyType<T> v)
            {   }
        }
