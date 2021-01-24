    public class TextVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private string _myText;
        public string MyText
        {
            get => _myText;
            set
            {
                _myText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyText"));
            }
        }
    }
