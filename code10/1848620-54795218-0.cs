    public class Point<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public T Z { get; set; }
        public Point<U> As<U>()
        {
            return new Point<U>()
            {
                X = Convert<T, U>(X),
                Y = Convert<T, U>(Y),
                Z = Convert<T, U>(Z)
            };
        }
        static U Convert<T, U>(T t) => (U)System.Convert.ChangeType(t, typeof(U));
    }
