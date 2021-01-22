    class Data<T> where T : new()
    {
        T obj;
        public Data()
        {
            obj = new T();
        }
    }
