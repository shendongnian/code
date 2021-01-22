    public class MyEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Dictionary<string, object> _customProps = new Dictionary<string, object>();
		public void AddCustomProperty(string key, object value)
		{
			_customProps.Add(key, value);
		}
		public object this[string key]
		{
			get { return _customProps[key]; }
			set
			{
				// The validation code of which you speak here.
				_customProps[key] = value;
				NotifyPropertyChanged("Item[" + key "]");
			}
		}
		private void NotifyPropertyChanged(string name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
    }
