        public string TextBoxInput
        {
            get { return _textBoxInput; }
            set
            {
                _textBoxInput = value;
                OnPropertyChanged(nameof(TextBoxInput));
            }
        }
        private string _textBoxInput;
