    public class MyViewModel: INotifyPropertyChanged
    {
        private String _originalText = "My Original Text";
        private String _modifyedText = "Place for Obfuscatet Text";
        public String OriginalText
        {
            get => _originalText;
            set
            {
                if (Equals(value, _originalText)) return;
                _originalText = value;
                OnPropertyChanged();
            }
        }
        public String ModifyedText
        {
            get => _modifyedText;
            set
            {
                if (Equals(value, _modifyedText)) return;
                _modifyedText = value;
                OnPropertyChanged();
            }
        }
        public ICommand Obfuscate { get; set; }
        public GuestViewModel()
        {
            Obfuscate = new RelayCommand(DoObfuscate, o => true);
        }
        private void DoObfuscate(object obj)
        {
            ModifyedText = DoModify(OriginalText);
        }
        //Implementation of INotifyPropertyChanged and DoModify etc...
    }
