     public class PostType
    {
        public static T[] extent<T>(int n)
        {
            T[] result = new T[n];
            if (!typeof(T).IsValueType)
            {
                Type type = typeof(T);
                object objTSource = Activator.CreateInstance(type);
                for (int i = 0; i < n; i++)
                {
                    result[i] = (T)objTSource;
                }
            }
            
            return result;
        }
    }
