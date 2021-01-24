    public class Wrapper : INotifyPropertyChanged
    {
        private readonly SharedModel _model;
        public Wrapper(SharedModel model)
        {
            _model = model;
        }
        private string _property;
        public string MyProperty
        {
            get { return _property; }
            set { _property = value; OnPropertyChanged(); }
        }
        //...
        public event PropertyChangedEventHandler PropertyChanged;
    }
