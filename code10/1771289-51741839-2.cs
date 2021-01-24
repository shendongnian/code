    public class Model
    {
        public Model()
        {
            Items = new IncrementalLoadingCollection();
        }
        //using the cusom collection
        public IncrementalLoadingCollection Items { get; set; }
    }
