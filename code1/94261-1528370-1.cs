    public static class Operator<T>
    {
         public static readonly Func<T, T, T> Plus;
         public static readonly Func<T, T, T> Minus;
         // etc
         static Operator()
         {
             // Build the delegates using expression trees, probably
         }
    }
