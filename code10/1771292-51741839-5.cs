    public class IncrementalLoadingCollection : ObservableCollection<Item>, ISupportIncrementalLoading
    {
        uint x = 0; //just for the example
        public bool HasMoreItems { get { return x < 10000; } } //maximum
        //the count is the number requested
        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            return AsyncInfo.Run(async cancelToken =>
            {
                //here you need to do your loading
                for (var c = x; c < x + count; c++)
                {
                    //add your newly loaded item to the collection
                    Add(new Item()
                    {
                        Text = c.ToString()
                    });
                }
                x += count;
                //return the actual number of items loaded (here it's just maxed)
                return new LoadMoreItemsResult { Count = count };
            });
        }
    }
