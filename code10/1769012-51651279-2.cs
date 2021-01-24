    public class CodeBehind : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private string simpleString;
        public string SimpleString
        {
            get{ return simpleString; }
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SimpleString"));
                simpleString = value;
            }
        }
    }
