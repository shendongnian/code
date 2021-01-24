    DocCollection = new GeneratorIncrementalLoadingClass<DataTest>(1000, (count) =>
    {
        return new DataTest() { Country = "Ghana" + count, City = "Wa" + count };
    });
    DocCollection.CollectionChanged += DocCollection_CollectionChanged;
    ACV = new AdvancedCollectionView(DocCollection, true);
    MyListView.ItemsSource = ACV;
    public class GeneratorIncrementalLoadingClass<T> : IncrementalLoadingBase
    {
        public GeneratorIncrementalLoadingClass(uint maxCount, Func<int, T> generator)
        {
            _generator = generator;
            _maxCount = maxCount;
        }
        protected async override Task<IList<object>> LoadMoreItemsOverrideAsync(System.Threading.CancellationToken c, uint count)
        {
            uint toGenerate = System.Math.Min(count, _maxCount - _count);
            // Wait for work 
            await Task.Delay(10);
            // This code simply generates
            var values = from j in Enumerable.Range((int)_count, (int)toGenerate)
                         select (object)_generator(j);
            _count += toGenerate;
            return values.ToArray();
        }
        protected override bool HasMoreItemsOverride()
        {
            return _count < _maxCount;
        }
        #region State
        Func<int, T> _generator;
        uint _count = 0;
        uint _maxCount;
        #endregion 
    }
    public abstract class IncrementalLoadingBase : IList, ISupportIncrementalLoading, INotifyCollectionChanged
    {
        #region IList
        public int Add(object value)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(object value)
        {
            return _storage.Contains(value);
        }
        public int IndexOf(object value)
        {
            return _storage.IndexOf(value);
        }
        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }
        public bool IsFixedSize
        {
            get { return false; }
        }
        public bool IsReadOnly
        {
            get { return true; }
        }
        public void Remove(object value)
        {
            throw new NotImplementedException();
        }
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
        public object this[int index]
        {
            get
            {
                return _storage[index];
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public void CopyTo(Array array, int index)
        {
            ((IList)_storage).CopyTo(array, index);
        }
        public int Count
        {
            get { return _storage.Count; }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }
        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
        public IEnumerator GetEnumerator()
        {
            return _storage.GetEnumerator();
        }
        #endregion
        #region ISupportIncrementalLoading
        public bool HasMoreItems
        {
            get { return HasMoreItemsOverride(); }
        }
        public Windows.Foundation.IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            if (_busy)
            {
                throw new InvalidOperationException("Only one operation in flight at a time");
            }
            _busy = true;
            return AsyncInfo.Run((c) => LoadMoreItemsAsync(c, count));
        }
        #endregion 
        #region INotifyCollectionChanged
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion 
        #region Private methods
        async Task<LoadMoreItemsResult> LoadMoreItemsAsync(CancellationToken c, uint count)
        {
            try
            {
                var items = await LoadMoreItemsOverrideAsync(c, count);
                var baseIndex = _storage.Count;
                _storage.AddRange(items);
                // Now notify of the new items
                NotifyOfInsertedItems(baseIndex, items.Count);
                return new LoadMoreItemsResult { Count = (uint)items.Count };
            }
            finally
            {
                _busy = false;
            }
        }
        void NotifyOfInsertedItems(int baseIndex, int count)
        {
            if (CollectionChanged == null)
            {
                return;
            }
            for (int i = 0; i < count; i++)
            {
                var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, _storage[i + baseIndex], i + baseIndex);
                CollectionChanged(this, args);
            }
        }
        #endregion
        #region Overridable methods
        protected abstract Task<IList<object>> LoadMoreItemsOverrideAsync(CancellationToken c, uint count);
        protected abstract bool HasMoreItemsOverride();
        #endregion 
        #region State
        List<object> _storage = new List<object>();
        bool _busy = false;
        #endregion 
    }
