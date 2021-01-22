    class Base<T> where T: Base<T>
    {
        public static T Get<T>()
        {
            // Return a suitable T.
        }
    }
