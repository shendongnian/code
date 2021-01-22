    struct Pair<T, R>
    {
        private T first_;
        private R second_;
        public T First
        {
            get { return first_; }
            set { first_ = value; }
        }
        public R Second
        {
            get { return second_; }
            set { second_ = value; }
        }
    }
