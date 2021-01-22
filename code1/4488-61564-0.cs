    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    
    namespace MyNamespace
    {
        public class ObservableCollectionWithBatchUpdates<T> : ObservableCollection<T>
        {
            public void AddRange(ICollection<T> obNewItems)
            {
                IList<T> obAddedItems = new List<T>();
                foreach (T obItem in obNewItems)
                {
                    Items.Add(obItem);
                    obAddedItems.Add(obItem);
                }
                NotifyCollectionChangedEventArgs obEvtArgs = new NotifyCollectionChangedEventArgs(
                   NotifyCollectionChangedAction.Add, 
                   obAddedItems as System.Collections.IList);
                base.OnCollectionChanged(obEvtArgs);
            }
    
        }
    }
