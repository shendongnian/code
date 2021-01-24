    public class MainWindowViewModel
    {
        public ObservableCollection<TypeModel> Collection { get; set; }
        public ObservableCollection<string> Type { get; set; }
        public Dictionary<string, List<string>> SubTypeCollection { get; set; }
        public MainWindowViewModel()
        {
            Collection = new ObservableCollection<TypeModel>();
            TypeCollection = new ObservableCollection<string>()
            {
                "Type 1","Type 2","Type 3"
            };
            SubTypeCollection = new Dictionary<string, List<string>>()
            {
                {
                    TypeCollection[0], new List<string>()
                    {
                        "Type 1 - Sub type 0",
                        "Type 1 - Sub type 1"
                    }
                },
                {
                    TypeCollection[1], new List<string>()
                    {
                        "Type 2 - Sub type 0",
                        "Type 2 - Sub type 1",
                        "Type 2 - Sub type 2",
                        "Type 3 - Sub type 3",
                    }
                },
                {
                    TypeCollection[2], new List<string>()
                    {
                        "Type 3 - Sub type 0",
                        "Type 3 - Sub type 1",
                        "Type 3 - Sub type 2",
                    }
                }
            };
        }
    }
