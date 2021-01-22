    public static class DBNullableExtensions
    {
        public static object ToDBValue<T>(this Nullable<T> value) where T:struct
        { 
            return value.HasValue ? (object)value.Value : DBNull.Value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int? x = null;
            Console.WriteLine(  x.ToDBValue() == DBNull.Value );
        }
    }
