    public static class ObjectExtensions
    {
        public static Nullable<T> ToNullable<T>(this object input)
            where T : struct
        {
            if (input == null)
                return null;
            if (input is Nullable<T> || input is T)
                return (Nullable<T>)input;
            throw new InvalidCastException();
        }
    }
