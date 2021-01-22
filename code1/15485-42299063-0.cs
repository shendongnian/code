    public static class NotifyPropertyChangedExtensions
    {
        private static bool _isFired = false;
        private static string _propertyName;
        public static void NotifyPropertyChangedVerificationSettingUp(this INotifyPropertyChanged notifyPropertyChanged,
          string propertyName)
        {
            _isFired = false;
            _propertyName = propertyName;
            notifyPropertyChanged.PropertyChanged += OnPropertyChanged;
        }
        private static void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == _propertyName)
            {
                _isFired = true;
            }
        }
        public static bool IsNotifyPropertyChangedFired(this INotifyPropertyChanged notifyPropertyChanged)
        {
            _propertyName = null;
            notifyPropertyChanged.PropertyChanged -= OnPropertyChanged;
            return _isFired;
        }
    }
