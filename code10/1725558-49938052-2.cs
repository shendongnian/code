        //private Field
        private Color _abColor = Colors.AliceBlue;
        //Public Property which the XAML binds to
        public Color ABColor
        {
            get { return _abColor; }
            set
            {
                _abColor = value;
                OnPropertyChanged();
            }
        }
