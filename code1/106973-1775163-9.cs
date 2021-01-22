    public class MyCollection2<T> : Collection<T>
    {
        public Func<T, bool> Validate { get; protected set; }
    
        public Action<T> AddAction { get; protected set; }
    
        public Action<T> RemoveAction { get; protected set; }
    
        public MyCollection2(Func<T, bool> validate, Action<T> add, Action<T> remove)
            : base()
        {
            Validate = Validate;
            AddAction = add;
            RemoveAction = remove;
        }
    
        protected override void ClearItems()
        {
            foreach (var item in this)
            {
                RemoveAction(item);
            }
            base.ClearItems();
        }
    
        protected override void InsertItem(int index, T item)
        {
            if (Validate(item))
            {
                AddAction(item);
                base.InsertItem(index, item);
            }
        }
    
        protected override void RemoveItem(int index)
        {
            RemoveAction(this[index]);
            base.RemoveItem(index);
        }
    
        protected override void SetItem(int index, T item)
        {
            if (Validate(item))
            {
                RemoveAction(this[index]);
                AddAction(item);
                base.SetItem(index, item);
            }
        }
    }
