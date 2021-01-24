       private object _ProductSelected;
          public object ProductSelected
        {
            get { return _ProductSelected; }
            set
            {
                _ProductSelected = value;
                OnPropertyChanged("ProductSelected"); //in case you are using MVVM Light
            }
        }
