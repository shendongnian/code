    public class StringItem
    {
        public string MyText { get; set; }
    }
    public class MyViewModel
    {
        public MyViewModel()
        {
            MyItems = new ObservableCollection<StringItem>();
            AddCmd = new RelayCommand<StringItem>(Add);
        }
        public ObservableCollection<StringItem> MyItems { get; private set; }
        public ICommand AddCmd { get; private set; }
        private void Add(StringItem current)
        {
            var item =new StringItem { MyText = "new item " + (MyItems.Count + 1) };
            int idx = MyItems.IndexOf(current);
            if (idx < 0)
                MyItems.Add(item);
            else 
                MyItems.Insert(idx + 1, item);
        }
    }
