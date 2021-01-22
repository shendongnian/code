    class MyCollection<T>: ICollection<T>
    {
        void Add(T item)
        {
            Remove(item);
        }
    }
