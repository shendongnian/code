    public class MainWindowViewModel 
    {
        public MainWindowViewModel()
        {
            GridItems = new ObservableCollection<GridItem>() {
            new GridItem() { Name = "Chef", PeopleId = 1 } };
            PeopleItems = new ObservableCollection<PeopleItem>() {
            new PeopleItem() { ID = 1, Name = "George" },
            new PeopleItem() { ID = 2, Name = "Martha" } };
        }
        public ObservableCollection<GridItem> GridItems { get; set; }
        public static ObservableCollection<PeopleItem> PeopleItems { get; set; }
    }
    public class GridItem
    {
        public string Name { get; set; }
        public int PeopleId { get; set; }
    }
    public class PeopleItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
