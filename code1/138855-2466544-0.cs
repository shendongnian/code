    public class BaseDataObject : INotifyPropertyChanged
    {
        public bool IsDirty
        {
            get { return _isDirty; }
            protected set { _isDirty = value; }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            _isDirty = true;
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        private bool _isDirty;
    }
    public class MyRealDataObject : BaseDataObject
    {
        public int MyIntProperty
        {
            get { return _myIntProperty; }
            set
            {
                bool changed = _myIntProperty != value;
                if (changed)
                {
                    _myIntProperty = value;
                    OnPropertyChanged("MyIntProperty");
                }
            }
        }
        private int _myIntProperty;
    }
