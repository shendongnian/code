    class MyList<T> : BindingList<T>
    {
        private readonly Foo<T> wrapped;
        public MyList(Foo<T> wrapped)
            : base(new List<T>(wrapped.Items))
        {
            this.wrapped = wrapped;
        }
        protected override void InsertItem(int index, T item)
        {
            wrapped.Insert(index, item);
            base.InsertItem(index, item);            
        }
        protected override void RemoveItem(int index)
        {
            wrapped.Remove(this[index]);
            base.RemoveItem(index);
        }
        protected override void ClearItems()
        {
            wrapped.Clear();
            base.ClearItems();
        }
        // possibly also SetItem
    }
