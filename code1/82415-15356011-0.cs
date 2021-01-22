     public class ViewModelBase : INotifyPropertyChanged
    {
        private Dictionary<string, object> _propertyStore = new Dictionary<string, object>();
        protected virtual void SetValue<T>(T value, [CallerMemberName] string propertyName="") {
            _propertyStore[propertyName] = value;
            OnPropertyChanged(propertyName);
        }
        protected virtual T GetValue<T>([CallerMemberName] string propertyName = "")
        {
            object ret;
            if (_propertyStore.TryGetValue(propertyName, out ret))
            {
                return (T)ret;
            }
            else
            {
                return default(T);
            }
        }
        //Usage
        //public string SomeProperty {
        //    get { return GetValue<string>();  }
        //    set { SetValue(value); }
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
