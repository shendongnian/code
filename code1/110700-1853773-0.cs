    public class A : INotifyPropertyChanged
    {
        
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        protected virtual void RaiseOnPropertyChanged(object sender, string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName);
        }
        public A()
        {
            this.PropertyChanged += new PropertyChangedEventHandler(A_PropertyChanged);
        }
        void A_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //centralised code here that deals with the changed property
        }
    }
    public class B : A
    {
        public string MyProperty
        {
            get { return _myProperty; }
            set 
            {
                _myProperty = value;
                RaiseOnPropertyChanged(this, "MyProperty");
            }
        }
        public string _myProperty = null;
    }
