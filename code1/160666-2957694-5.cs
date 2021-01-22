    public class ItemViewModel
    {
        public double Left { get; set; }
        public double Top { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        // whatever you need...
    }
    public class CollectionViewModel
    {
        public ObservableCollection<ItemViewModel> Collection { get; }
        // some code which fills the Collection with items
    }
