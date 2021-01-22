    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace TestGround
    {
        public class MyCollection<T> : Collection<T>
        {
            public class ListChangeEventArgs : EventArgs
            {
                public IEnumerable<T> ItemsInvolved { get; set;}
    
                public int? Index { get; set;}
            }
    
            public delegate void ListEventHandler(object sender, ListChangeEventArgs e);
    
            public event ListEventHandler Inserting;
    
            public event ListEventHandler Setting;
    
            public event ListEventHandler Clearing;
    
            public event ListEventHandler Removing;
    
            public MyCollection() : base() { }
    
            public MyCollection(IList<T> innerList) : base(innerList) { }
    
            protected override void ClearItems()
            {
                Clearing(this, new ListChangeEventArgs()
                {
                     Index = null,
                     ItemsInvolved = this.ToArray(),
                });
                base.ClearItems();
            }
    
            protected override void InsertItem(int index, T item)
            {
                Inserting(this, new ListChangeEventArgs()
                {
                    Index = index,
                    ItemsInvolved = new T[] { item },
                });
                base.InsertItem(index, item);
            }
    
            protected override void RemoveItem(int index)
            {
                Removing(this, new ListChangeEventArgs()
                {
                    Index = index,
                    ItemsInvolved = new T[] { this[index] },
                });
                base.RemoveItem(index);
            }
    
            protected override void SetItem(int index, T item)
            {
                Setting(this, new ListChangeEventArgs()
                {
                    Index = index,
                    ItemsInvolved = new T[] { item },
                });
                base.SetItem(index, item);
            }
        }
    }
