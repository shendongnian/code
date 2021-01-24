    public class Point<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public T Z { get; set; }
        public Point<U> As<U>()
        {
            return new Point<U>()
            {
                X = Convert<U>(X),
                Y = Convert<U>(Y),
                Z = Convert<U>(Z)
            };
        }
        static U Convert<U>(T t) => (U)System.Convert.ChangeType(t, typeof(U));
    }
