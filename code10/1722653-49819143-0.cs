    public class MyItemViewModel
    {
        public MyItemViewModel(bool changeBackground)
        {
            this.ChangeBackground = changeBackground;
        }
    
        public bool ChangeBackground { get; set; }
    }
    public class MyListViewModel
    {
        public ObservableCollection<MyItemViewModel> MyItems { get; set; }
    
        private void MyItemsInit()
        {
             this.MyItems = new ObservableCollection<MyItemViewModel>();
    
             for (int i = 0; i < 10; i++)
                 this.MyItems.Add(new MyItemViewModel(i % 2 == 0));
        }
    }
