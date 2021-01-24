    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private double gridHeight = 500.0;
        public double GridHeight
        {
            get { return gridHeight; }
            private set { gridHeight = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GridHeight))); }
        }
    
    
        private double gridWidth = 500.0;
        public double GridWidth
        {
            get { return gridWidth; }
            private set { gridWidth = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GridWidth))); }
        }
    
    
        private int scaleX = 1;
        public int ScaleX
        {
            get { return scaleX; }
            set
            {
                if (value > 0)
                {
                    var oldScaleX = scaleX;
                    scaleX = value;
                    GridWidth *= (double)scaleX / oldScaleX;
                }
    
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScaleX)));
            }
        }
    
    
        private int scaleY = 1;
        public int ScaleY
        {
            get { return scaleY; }
            set
            {
                if (value > 0)
                {
                    var oldScaleY = scaleY;
                    scaleY = value;
                    GridHeight *= (double)scaleY / oldScaleY;
                }
    
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScaleY)));
            }
        }
    }
