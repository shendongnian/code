    class RootViewModel : INotifyPropertyCahnged
    {
        ...
        private object _ViewContent;
        public object ViewContent
        {
            get {return _ViewContent;}
            set
            {
                _ViewContent = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged ("ViewContent");
                }
    
            }
        }
        private RelayCommand _ShowMainView;
        public ICommand ShowMainView
        {
            get 
            {
                if (_ShowMainView == null)
                {
                    _ShowMainView = new RelayCommand(x => ViewContent = new MainViewModel());
                }
                return _ShowMainView;
            }
        }
        ...
    }
