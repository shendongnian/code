    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> CastEnumerable<T>(this IEnumerable<object> sourceEnum)
        {
            if(sourceEnum == null)
                return new List<T>();
            try
            {
                // Covert the objects in the list to the target type (T) 
                // (this allows to receive other types and then convert in the desired type)
                var convertedEnum = sourceEnum.Select(x => Convert.ChangeType(x, typeof(T)));
                // Cast the IEnumerable<object> to IEnumerable<T>
                return convertedEnum.Cast<T>();
            }
            catch (Exception e)
            {
                throw new InvalidCastException($"There was a problem converting {sourceEnum.GetType()} to {typeof(IEnumerable<T>)}", e);
            }
        }
    }
