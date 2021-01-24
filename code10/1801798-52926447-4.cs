    public class ColorModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private int red;
        private int green;
        private int blue;
        public int RedValue
        {
            get { return red; }
            set
            {
                if (red != value)
                {
                    red = value;
                    OnPropertyChanged(nameof(RedValue));
                    OnPropertyChanged(nameof(Result));
                }
            }
        }
        public int GreenValue
        {
            get { return green; }
            set
            {
                if (green != value)
                {
                    green = value;
                    OnPropertyChanged(nameof(GreenValue));
                    OnPropertyChanged(nameof(Result));
                }
            }
        }
        public int BlueValue
        {
            get { return blue; }
            set
            {
                if (blue != value)
                {
                    blue = value;
                    OnPropertyChanged(nameof(BlueValue));
                    OnPropertyChanged(nameof(Result));
                }
            }
        }
        public Color Result
        {
            get
            {
                return Color.FromRgb((byte)red, (byte)green, (byte)blue);
            }
        }
    }
