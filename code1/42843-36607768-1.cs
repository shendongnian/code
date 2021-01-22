    public class CollectionReplacedEventArgs<T> : ReplacedEventArgs<T>
    {
        public CollectionReplacedEventArgs(IEnumerable<T> Old, IEnumerable<T> New) : base(Old, New) { }
    }
    public class ItemAddedEventArgs<T> : EventArgs
    {
        public T NewItem;
        public ItemAddedEventArgs(T t)
        {
            this.NewItem = t;
        }
    }
    public class ItemInsertedEventArgs<T> : EventArgs
    {
        public int Index;
        public T NewItem;
        public ItemInsertedEventArgs(T t, int i)
        {
            this.NewItem = t;
            this.Index = i;
        }
    }
    public class ItemRemovedEventArgs<T> : EventArgs
    {
        public T OldItem;
        public ItemRemovedEventArgs(T t)
        {
            this.OldItem = t;
        }
    }
    public class ItemReplacedEventArgs<T> : EventArgs
    {
        public T OldItem;
        public T NewItem;
        public ItemReplacedEventArgs(T Old, T New)
        {
            this.OldItem = Old;
            this.NewItem = New;
        }
    }
    public class ItemsAddedEventArgs<T> : EventArgs
    {
        public IEnumerable<T> NewItems;
        public ItemsAddedEventArgs(IEnumerable<T> t)
        {
            this.NewItems = t;
        }
    }
    public class ItemsClearedEventArgs<T> : RemovedEventArgs<T>
    {
        public ItemsClearedEventArgs(IEnumerable<T> Old) : base(Old) { }
    }
    public class ItemsRemovedEventArgs<T> : RemovedEventArgs<T>
    {
        public ItemsRemovedEventArgs(IEnumerable<T> Old) : base(Old) { }
    }
    public class ItemsReplacedEventArgs<T> : ReplacedEventArgs<T>
    {
        public ItemsReplacedEventArgs(IEnumerable<T> Old, IEnumerable<T> New) : base(Old, New) { }
    }
    public class RemovedEventArgs<T> : EventArgs
    {
        public IEnumerable<T> OldItems;
        public RemovedEventArgs(IEnumerable<T> Old)
        {
            this.OldItems = Old;
        }
    }
    public class ReplacedEventArgs<T> : EventArgs
    {
        public IEnumerable<T> OldItems;
        public IEnumerable<T> NewItems;
        public ReplacedEventArgs(IEnumerable<T> Old, IEnumerable<T> New)
        {
            this.OldItems = Old;
            this.NewItems = New;
        }
    }
