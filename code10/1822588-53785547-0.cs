      private decimal _money;
            public decimal Money
            {
                get { return _money; }
                set {
                   
                     _money = value;
                    _money.ToString("0.##");
    
                     NotifyPropertyChanged("Money"); }
            }
