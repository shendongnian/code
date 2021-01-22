    public class Observable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void SetProperty<T>(ref T backingField, T newValue,
            string propertyName)
        {
            if (Equals(backingField, newValue))
                return;
            backingField = newValue;
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
