    class A<T>
    {
        public List<T> data = new List<T>();
        public Type typeOfDataInList;
        public A()
        {
            typeOfDataInList = typeof(T);
        }
        public void Fill(T[] items)
        {
            data.AddRange(items);
        }
    }
