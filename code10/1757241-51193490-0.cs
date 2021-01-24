    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly Model Data;
        public MainViewModel()
        {
            Data = new Model();
            Data.PropertyChanged += Data_PropertyChanged;
        }
        private void Data_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("BoundTextProperty");
        }
        public string BoundTextProperty => Data.BoundTextProperty;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
