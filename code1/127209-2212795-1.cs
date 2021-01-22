    sealed class MyBindingList<T> : BindingList<T>
    {
        public MyBindingList(IList<T> collection)
            : base(collection)
        {
            for(int i = 0; i < collection.Count; ++i)
            {
                OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, idx));
            }
        }
    }
