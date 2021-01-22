    public class MyCollection2<T, TParent> : Collection<T>
        where T : EntityWithParent
        where TParent : Entity
    {
        public Func<T, bool> Validate { get; protected set; }
    
        public TParent ParentInstance { get; protected set; }
    
        public MyCollection2(Func<T, bool> validate, TParent parentInstance)
            : base()
        {
            Validate = Validate;
            ParentInstance = parentInstance;
        }
    
        protected override void ClearItems()
        {
            foreach (var item in this)
            {
                item.Parent = null;
            }
            base.ClearItems();
        }
    
        protected override void InsertItem(int index, T item)
        {
            if (Validate(item))
            {
                item.Parent = ParentInstance;
                base.InsertItem(index, item);
            }
        }
    
        protected override void RemoveItem(int index)
        {
            this[index].Parent = null;
            base.RemoveItem(index);
        }
    
        protected override void SetItem(int index, T item)
        {
            if (Validate(item))
            {
                this[index].Parent = null;
                item.Parent = ParentInstance;
                base.SetItem(index, item);
            }
        }
    }
