    public static class RaisePropertyChangedExtension
    {
        public static void RaisePropertyChanged(this INotifyPropertyChanged @this, [CallerMemberName] string propertyName = null)
        {
            (@this.GetType().GetField(nameof(INotifyPropertyChanged.PropertyChanged), BindingFlags.Instance | BindingFlags.NonPublic).GetValue(@this) as PropertyChangedEventHandler)?.Invoke(@this, new PropertyChangedEventArgs(propertyName));
        }
    }
