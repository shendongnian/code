    public class MyClass: System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public string AValue
        {
            get
            {
                return this._AValue;
            }
            set
            {
                if (value != this._AValue)
                {
                    this._AValue = value;
                    this.OnPropertyChanged("AValue");
                }
            }
        }
        private string _AValue;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
