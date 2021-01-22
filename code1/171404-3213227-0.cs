    static class NullExtensions
    {
        public static T WhenNull<T>( this object value, T whenNullValue )
        {
            return (value == null || value is DBNull)
                ? whenNullValue
                : (T)value;
        }
    }
