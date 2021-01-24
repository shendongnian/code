        public double OpacityBackground
        {
            get { return btnBackground.Opacity; }
            set
            {
                btnBackground.Opacity = value;
                OnPropertyChanged("OpacityBackground");
                
                OnPanelChangeData?.Invoke(this, new OnPanelChangeArgs()
                {
                    Value = btnBackground.Opacity.ToString(),
                    Type = OnChangeType.Opacity
                });
            }
        }
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
