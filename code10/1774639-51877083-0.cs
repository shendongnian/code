        Class X : INotifyPropertyChanged{
        private bool _changed;
        private string _foo;
        public string Foo
        {
            get => _foo;
            set { _foo = value; _changed = true;  }
        }
        protected void OnPropertyChanged(string propertyName){
            _changed = true;
        }
        
        
        }
