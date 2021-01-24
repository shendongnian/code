    public class Book
    {
        public string Title { get; set; }
        public ObservableCollection<Chapter> AvailableChapters { get; }
            = new ObservableCollection<Chapter>();
    }
