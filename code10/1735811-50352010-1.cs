    public class TabViewModel
    {
        public TabViewModel()
        {
            Items = new ObservableCollection<Item>()
            {
                new Item { Header = "a", Content = "..." },
                new Item { Header = "b", Content = "..." },
                new Item { Header = "c", Content = "..." },
            };
        }
        public ObservableCollection<Item> Items { get; set; }
    }
