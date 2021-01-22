    public class SyncBindingWrapper: INotifyPropertyChanged
    {
        private readonly INotifyPropertyChanged _source;
        private readonly PropertyInfo _property;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly SynchronizationContext _context;
        public object Value
        {
            get
            {
                return _property.GetValue(_source, null);
            }
        }
        public SyncBindingWrapper(INotifyPropertyChanged source, string propertyName)
        {
            _context = SynchronizationContext.Current;
            _source = source;
            _property = source.GetType().GetProperty(propertyName);
            source.PropertyChanged += OnSourcePropertyChanged;
        }
        private void OnSourcePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null && e.PropertyName == _property.Name)
            {
                _context.Send(state => propertyChanged(this, new PropertyChangedEventArgs("Value")), null);
            }
        }
    }
