    class CustomeCollection<T> : List<T>
    {
        public new void Add(T item)
        {
            //Validate Here
            base.Add(item);
        }
        public new void Remove(T item)
        {
            //Validate Here
            base.Remove(item);
        }
    }
