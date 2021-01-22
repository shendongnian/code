    class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public MyViewModel(MyModel mdl)
        {
            mdl.PropertyChanged += 
                new PropertyChangedEventHandler(
                    mdl_PropertyChanged);
            _mdl = mdl;
        }
        private MyModel _mdl = null;
        void mdl_PropertyChanged(object sender, 
            PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Foo")
            {
                this.Foo = _mdl.Foo;
            }
        }
        public int Foo
        {
            get
            {
                lock(_foo_Lock)
                {
                    return _foo;
                }
            }
            set
            {
                lock(_foo_Lock)
                {
                    _foo = value;
                }
                NotifyPropertyChanged("Foo");
            }
        }
        private readonly object _foo_Lock = new object();
        private int _foo = 0;
    }
