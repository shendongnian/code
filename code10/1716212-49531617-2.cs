        private string inputString;
        public string InputString
        {
            get { return inputString; }
            set
            {
                inputString = value;
                OutputString = $"{inputString.Length} characters entered";
                RaisePropertyChanged();
            }
        }
        private string outputString;
        public string OutputString
        {
            get { return outputString; }
            set
            {
                outputString = value;
                RaisePropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
