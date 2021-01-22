        public string PasswordChar
        {
            get
            {
                string szChar = "";
                foreach(char szCahr in _Password)
                {
                    szChar = szChar + "*";
                }
                return szChar;
            }
            set
            {
                _PasswordChar = value; NotifyPropertyChanged();
            }
        }
