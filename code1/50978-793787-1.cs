        public static Nullable<T> ConvertToNullable<T>(this string s) where T : struct
        {
            if (!string.IsNullOrEmpty(s.Trim()))
            {
                TypeConverter conv = TypeDescriptor.GetConverter(typeof(Nullable<>).MakeGenericType(typeof(T)));
                return (Nullable<T>)conv.ConvertFrom(s);
            }
            return null;
        }
