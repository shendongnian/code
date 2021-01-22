    public abstract class Enumeration<TEnum, X, Y> : IComparable 
        where TEnum : Enumeration<TEnum, X, Y>
        where X : IComparable
    {
        public static TEnum Resolve(X value) { /* your lookup here */ }
        // other members same as before; elided for clarity
    }
