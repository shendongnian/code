    public class MovieViewModel : INotifyPropertyChanged
    {
        readonly List<Movies> _m;
        private ICommand _testCommand = null;
        public ICommand TestCommand { get { return _testCommand; } set { _testCommand = value; NotifyPropertyChanged("TestCommand"); } }
        public MovieViewModel(List<Movies> m)
        {
            this.TestCommand = new TestCommand(this);
            _m = m;        
        }
        public List<Movies> lm
        {
            get
            {
                return _m;
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string sProp)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(sProp));
            }
        }    
    }
