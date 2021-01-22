    public static MyLinqExtensions 
    {
         public static void Run<T>(this IEnumerable<T> e)
         {
             foreach (var _ in e);
         }
    }
