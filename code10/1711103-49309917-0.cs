    struct MySet<T>
    {
        public readonly static MySet<T> Empty = default(MySet<T>);
        private ImmutableHashSet<T> items;
        private MySet(ImmutableHashSet<T> items) => this.items = items;
        public ImmutableHashSet<T> Items => this.items ?? ImmutableHashSet<T>.Empty;
        public MySet<T> Add(T item) => new MySet<T>(this.Items.Add(item));
        public static MySet<T> operator |(T item, MySet<T> items) => items.Add(item);
        public static MySet<T> operator |(MySet<T> items, T item) => items.Add(item);
        public static MySet<T> operator |(MySet<T> x, MySet<T> y) => new MySet<T>(x.Items.Union(y.Items));
        public static MySet<T> operator &(MySet<T> items, T item) => new MySet<T>(items.Items.Contains(item) ? ImmutableHashSet<T>.Empty.Add(item) : ImmutableHashSet<T>.Empty);
        public static MySet<T> operator &(T item, MySet<T> items) => new MySet<T>(items.Items.Contains(item) ? ImmutableHashSet<T>.Empty.Add(item) : ImmutableHashSet<T>.Empty);
        public static MySet<T> operator &(MySet<T> x, MySet<T> y) => new MySet<T>(x.Items.Intersect(y.Items));
    }
