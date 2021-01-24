    public class ViewModel
    {
        public ViewModel()
        {
            Items = new IncrementalLoadingCollection();
        }
        //using the custom collection: these are your loaded items
        public IncrementalLoadingCollection Items { get; set; }
    }
