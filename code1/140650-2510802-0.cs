    class A<T>
    {
        public List<T> data = new List<T>();
        public Type typeOfDataInList;
        public void Fill(T[] items)
        {
            data.AddRange(items);
            typeOfDataInList = typeof(T);
        }
    }
