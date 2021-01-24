    public class Point<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public T Z { get; set; }
        public static explicit operator Point<T>(Point<int> v)
        {
            return v.As<T>();
        }
        public static explicit operator Point<T>(Point<double> v)
        {
            return v.As<T>();
        }
        public static explicit operator Point<T>(Point<float> v)
        {
            return v.As<T>();
        }
        public Point<TU> As<TU>()
        {
            return new Point<TU>()
            {
                X = ConvertTo<TU>(X),
                Y = ConvertTo<TU>(Y),
                Z = ConvertTo<TU>(Z)
            };
        }
        private static TU ConvertTo<TU>(T t)
        {
            return (TU) Convert.ChangeType(t, typeof(TU));
        }
    }
