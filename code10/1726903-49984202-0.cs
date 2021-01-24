    public class Util
    {
        public static T[] Transform<T>(T[] values, Transformer<T> t)
        {
            return values.Select(x => t(x)).ToArray();
        }
    }
