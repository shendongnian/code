    public static class GenericExtension
    {
        public static T? ConvertToNullable<T>(this String s) where T : struct 
        {
            try
            {
                return (T?)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(s);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
