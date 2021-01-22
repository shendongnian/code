    class UC1ViewModel : INotifyPropertyChanged
    {
        ...
        private MainViewModel _Parent;
        public UC1ViewModel(MainViewModel parent)
        {
            _Panert = parent;
        }
    
        private RelayCommand _AddItemToUC2;
        public ICommand AddItemToUC2
        {
            get
            {
                if (_AddItemToUC2 = null)
                {
                    // UC2Content is UC2ViewModel
                    // Items is ObservableCollection
                   _AddItemToUC2 = new RelayCommand(x => _Parent.UC2Content.Items.Add(...));
                }
                return AddItemToUC2;
            }
        }
        ...
    }
