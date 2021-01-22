    public abstract class AbstractObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool SetValue<TKind>(ref TKind Source, TKind NewValue, params string[] Notify)
        {
            //Set value if the new value is different from the old
            if (!Source.Equals(NewValue))
            {
                Source = NewValue;
                //Notify all applicable properties
                foreach (var i in Notify)
                    OnPropertyChanged(i);
                return true;
            }
            return false;
        }
        public AbstractObject()
        {
        }
    }
