    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    public class CollectionEventArgs<T> : EventArgs
    {
        public static readonly CollectionEventArgs<T> Empty = new CollectionEventArgs<T>();
        public CollectionEventArgs(params T[] items)
        {
            this.Items = new ReadOnlyCollection<T>(items);
        }
        public CollectionEventArgs(IEnumerable<T> items)
        {
            this.Items = new ReadOnlyCollection<T>(items.ToArray());
        }
        public ReadOnlyCollection<T> Items
        {
            get;
            private set;
        }
    }
