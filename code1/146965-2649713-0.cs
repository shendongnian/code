      public class MyCustomCollection : INotifyCollectionChanged
        {
            public event NotifyCollectionChangedEventHandler CollectionChanged;
    
            protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
            {
                if (CollectionChanged != null)
                {
                    CollectionChanged(this, e);
                }
            }
    
            public void Add(Object o)
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, o));
            }
    
            public void Remove(Object o)
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, 0));
            }
    
            public void Clear()
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
    
            public void Move(Object o, Int32 newIndex)
            {
                Int32 oldIndex = 0; // can get the old index position using collection.IndexOf(o);
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move,
                    o, newIndex, oldIndex));
            }
    
            public Object this[Int32 index]
            {
                get
                {
                    return null; // return collection[index];
                }
                set
                {
                    Object oldValue = null;  // get old value using collection[index];
                    OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace,
                        value, oldValue));
                }
            }
        }
