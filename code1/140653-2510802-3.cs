    class A<T>
    {
        public readonly List<T> Data = new List<T>();
        public Type TypeOfDataInList { get; private set; }
        public A()
        {
            TypeOfDataInList = typeof(T);
        }
        public void Fill(params T[] items)
        {
            data.AddRange(items);
        }
    }
