    public class GenericsManager
    {
        public static T ChangeType<T>(object data)
        {
            T value = default(T);
            if (typeof(T).IsGenericType &&
              typeof(T).GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                value = (T)Convert.ChangeType(data, Nullable.GetUnderlyingType(typeof(T)));
            }
            else
            {
                if (data != null)
                {
                    value = (T)Convert.ChangeType(data, typeof(T));
                }
            }
            return value;
        }
    }
