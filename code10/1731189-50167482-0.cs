      public Class1()
            {
                TextList = new ObservableCollection<string> { "TEXT1", "TEXT2" };
            }
            private string _X;
            public string X
            {
                get { return _X; }
                set
                {
                    _X = value;
                    if (PropertyChanged != null)
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("X"));
                }
            }
            public ObservableCollection<string> TextList { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;
