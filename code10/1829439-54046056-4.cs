    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _somePropertyOnMyViewModel;
        public string SomePropertyOnMyViewModel
        {
            get => _somePropertyOnMyViewModel;
            set { _somePropertyOnMyViewModel = value; OnPropertyChanged(); }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
