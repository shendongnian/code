    class MyRef<T> 
    {
        private Func<T> getter;
        public MyRef(Func<T> getter)
        {
            this.getter = getter;
        }
        public T Value
        {
            get { return getter(); }
        }
    }
