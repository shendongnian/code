     private void TurnOnFlashingBackround()
        {
            FlashingBackground = "ON";
        }
    
        private string _FlashingBackround = "OFF";
    
        public string FlashingBackground
        {
            get { return _FlashingBackround; }
    
            private set
            {
                if (FlashingBackground == value)
                {
                    return;
                }
    
                _FlashingBackround = value;
                this.OnPropertyChanged("FlashingBackground");
            }
        }
        public new event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
