    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void SetValue<T>(
            ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(storage, value))
            {
                storage = value;
                OnPropertyChanged(propertyName);
            }
        }
    }
    public class Train : ViewModelBase
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { SetValue(ref name, value); }
        }
        private string details;
        public string Details
        {
            get { return details; }
            set { SetValue(ref details, value); }
        }
        // more properties
    }
    public class TrainViewModel : ViewModelBase
    {
        public ObservableCollection<Train> Trains { get; }
            = new ObservableCollection<Train>();
        private Train selectedTrain;
        public Train SelectedTrain
        {
            get { return selectedTrain; }
            set { SetValue(ref selectedTrain, value); }
        }
    }
    public class MainViewModel
    {
        public TrainViewModel TrainViewModel { get; } = new TrainViewModel();
    }
