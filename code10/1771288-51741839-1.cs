    public class IncrementalLoadingCollection : ObservableCollection<Item>, ISupportIncrementalLoading
    {
        uint x = 0;
        public bool HasMoreItems { get { return x < 10000; } } //maximum
        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            return AsyncInfo.Run(async cancelToken =>
            {
                //here you need to do your loading
                for (var c = x; c < x + count; c++)
                {
                    Add(new Item()
                    {
                        Text = c.ToString()
                    });
                }
                x += count;
                return new LoadMoreItemsResult { Count = count };
            });
        }
    }
