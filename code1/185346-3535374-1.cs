            public string LanguageCode
        {
            get
            {
                return _languageCode;
            }
            set
            {
                _languageCode = value;
                NotifyPropertyChanged("LanguageCode");
            }
        }
