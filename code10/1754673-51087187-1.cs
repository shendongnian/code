     public class ProgressViewModel:INotifyPropertyChanged
    {
        private int _progress;
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ProgressViewModel()
        {
            ProgressBarEvent.GetInstance().ProgressChanged += (s, e) => Application.Current.Dispatcher.Invoke(()=> Progress = e);
        }
        public int Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                OnPropertyChanged();
            }
        }
    }
