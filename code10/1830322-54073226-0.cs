    public sealed class MomViewModel : INotifyPropertyChanged, IDisposable
    {
        private readonly System.Timers.Timer _timer = new System.Timers.Timer();
        public MomViewModel()
        {
            _timer.Interval = 2000;
            _timer.Elapsed += (s, e) => Selected = new Mom();
            _timer.Start();
        }
        private Mom selected;
        public Mom Selected
        {
            get => selected;
            set => Set(ref selected, value);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void Set<T>(ref T field, T newValue = default(T), [CallerMemberName] string propertyName = null)
        {
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
    }
