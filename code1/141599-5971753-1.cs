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
