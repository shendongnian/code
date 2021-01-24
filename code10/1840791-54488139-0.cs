private void CopyFrom(IEnumerable<T> collection)
        {
            IList<T> items = Items;
            if (collection != null && items != null)
            {
                using (IEnumerator<T> enumerator = collection.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        items.Add(enumerator.Current);
                    }
                }
            }
        }
In the delegate of Parallel.For you are using a lock. You could use this as well for the property changed event:
                    lock(myModel.Objects)
                    {
                    collectionView = new ObservableCollection<MyObject>(myModel.Objects);
                    }
Or add the event raising to the lock in the Parallel.For delegate
lock (Objects)
                    {
                        Objects.Add(myOb);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Objects"));
                    }
Or you could just wait until all items are read and then raise one property changed event after completing the Parallel.For.
