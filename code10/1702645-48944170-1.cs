     public class MyViewModel : INotifyPropertyChanged
    {
        private string _a;
        private string _b;
        private string _c;
        public string A
        {
            get => _a;
            set
            {
                _a = value;
                OnPropertyChanged(nameof(A));
                OnPropertyChanged(nameof(D));
            }
        }
        public string B
        {
            get => _b;
            set
            {
                _b = value;
                OnPropertyChanged(nameof(B));
                OnPropertyChanged(nameof(D));
            }
        }
        public string C
        {
            get => _c;
            set
            {
                _c = value;
                OnPropertyChanged(nameof(C));
                OnPropertyChanged(nameof(D));
            }
        }
        public string D => $"{A} {B} {C}";
        public List<string> MyTexts { get; }
        public MyViewModel()
        {
            MyTexts = new List<string>() { "FHAKWEFJ AWKEEF AWEKF LAEWKF LAWEF", "AAAAAAAAAAAAAAAAAAAAAA", "BBBBBBBBBBBBBBBBBBBBBBBBB", "EEEEEEEEEEEEEEEEEEEEEEEEE", "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG", "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" };
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
