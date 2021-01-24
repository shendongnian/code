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
