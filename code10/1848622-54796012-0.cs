    public class Point<T> where T : IConvertible
    {
        // ...
    
        public static explicit operator Point<int>(Point<T> point)
        {
            // The IFormatProvider parameter has no effect on purely numeric conversions
            return new Point<int>(point.X.ToInt32(null), point.Y.ToInt32(null), point.Y.ToInt32(null));
        }    
    }
