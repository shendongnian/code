    public class ProgressViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                OnPropertyChanged();
            }
        }
        public ProgressViewModel()
        {
            var random = new Random();
            var timer = new Timer
            {
                Interval = 200,
            };
           
            timer.Elapsed += (s, e) => FileName = random.Next().ToString();
            timer.Start();
        }
    }
