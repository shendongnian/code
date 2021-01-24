    class ListWithAdd<T> : List<T>
    {
        public new void Add(T item)
        {
            base.Add(item);
            DoStuff();
        }
    }
