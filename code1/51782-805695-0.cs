    class SomeType : INotifyPropertyChanged {
        private int foo;
        public int Foo {
            get { return foo; }
            set { SetField(ref foo, value, "Foo"); }
        }
    
        private string bar;
        public string Bar {
            get { return bar; }
            set { SetField(ref bar, value, "Bar"); }
        }
    
        public bool IsDirty { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void SetField<T>(ref T field, T value, string propertyName) {
            if (!EqualityComparer<T>.Default.Equals(field, value)) {
                field = value;
                IsDirty = true;
                OnPropertyChanged(propertyName);
            }
        }
        protected virtual void OnPropertyChanged(string propertyName) {
            var handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
