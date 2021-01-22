    static public class MyGenericHelper
    {
        static public bool EqualsByValue<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }
    
        static public bool EqualsByReference<T>(T x, T y)
        {
            if (x is ValueType) return EqualityComparer<T>.Default.Equals(x, y) // avoids boxing
    
            return Object.ReferenceEquals(x, y);
        }
    }
