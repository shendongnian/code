    public class Bilder : INotifyPropertyChanged
    {
        public string Bild { get; set; }
        private SolidColorBrush borderBrush;
        public SolidColorBrush BorderColor
        {
            get { return borderBrush; }
            set
            {
                borderBrush = value;
                OnPropertyChanged(nameof(BorderColor));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
