    public class MyClass : INotifyPropertyChanged
    {
        private string myString;
    
        public string MyString
        {
            get
            { return myString; }
            set
            {
                myString = value;
                OnPropertyChanged("MyString");
            }
        }
    
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            { handler(this, new PropertyChangedEventArgs(propertyName)); }
        }
    
        #region INotifyPropertyChanged Members
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        #endregion
    }
