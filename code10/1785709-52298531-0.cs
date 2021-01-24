    public class ViewModel : INotifyDataErrorInfo
    {
        public Key LoadedBackgroundKey
        {
            get => keys[0];
            set
            {
                Validate(nameof(LoadedBackgroundKey), value);
                keys[0] = value;
            }
        }
        public Key LoadedForegroundKey
        {
            get => keys[1];
            set
            {
                Validate(nameof(LoadedForegroundKey), value);
                keys[1] = value;
            }
        }
        public Key IncreaseSizeKey
        {
            get => keys[2];
            set
            {
                Validate(nameof(IncreaseSizeKey), value);
                keys[2] = value;
            }
        }
        public IEnumerable<Key> Keys { get; } = new ObservableCollection<Key> { ... };
        private void Validate(string propertyName, Key value)
        {
            if (keys.Contains(value))
                _validationErrors[propertyName] = "duplicate...";
            else
                _validationErrors.Remove(propertyName);
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        private readonly Key[] keys = new Key[3];
        private readonly Dictionary<string, string> _validationErrors = new Dictionary<string, string>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public bool HasErrors => _validationErrors.Count > 0;
        public IEnumerable GetErrors(string propertyName) =>
            _validationErrors.TryGetValue(propertyName, out string error) ? new string[1] { error } : null;
    }
