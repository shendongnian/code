    class TestViewModel
    {
        public class Item : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            public string Test { get; set; }
            public ObservableCollection<string> SubItems { get; set; }
    
            private string _selectItme;
    
            public string SelectItme
            {
                get
                {
                    return _selectItme;
                }
                set
                {
                    _selectItme = value;
                    OnPropertyChanged();
                }
            }
            public Item()
            {
                SubItems = new ObservableCollection<string>() { "zhuzhu", "heheh", "liuliu", "momo" };
            }
    
            public ICommand ItemCommand
            {
                get
                {
                    return new CommadEventHandler<object>((item) => ItemClick(item));
                }
            }
            private void ItemClick(object item)
            {
                System.Diagnostics.Debug.WriteLine("--------------------");
            }
        }
    
        public ObservableCollection<Item> Items { get; set; }
    
        public TestViewModel()
        {
            Items = new ObservableCollection<Item>();
    
            Items.Add(new Item { Test = "Item 1" });
            Items.Add(new Item { Test = "Item 2" });
            Items.Add(new Item { Test = "Item 3" });
            Items.Add(new Item { Test = "Item 4" });
            Items.Add(new Item { Test = "Item 5" });
            Items.Add(new Item { Test = "Item 7" });
            Items.Add(new Item { Test = "Item 8" });
            Items.Add(new Item { Test = "Item 9" });
            Items.Add(new Item { Test = "Item 10" });
            Items.Add(new Item { Test = "Item 11" });
        }
    
    }
    
    class CommadEventHandler<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;
    
        public Action<T> action;
        public bool CanExecute(object parameter)
        {
            return true;
        }
    
        public void Execute(object parameter)
        {
            this.action((T)parameter);
        }
        public CommadEventHandler(Action<T> action)
        {
            this.action = action;
    
        }
    }
