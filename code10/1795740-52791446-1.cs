        private bool isButton1Active;
        private bool isButton2Active;
        public bool IsButton1Active
        {
            get { return isButton1Active; }
            set { isButton1Active = value; OnPropertyChanged(); }
        }
        public bool IsButton2Active
        {
            get { return isButton2Active; }
            set { isButton2Active = value; OnPropertyChanged(); }
        }
