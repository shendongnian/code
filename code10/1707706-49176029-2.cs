    public class CustomLine : INotifyPropertyChanged
    {
        private double _X1;
        private double _X2;
        private double _Y1;
        private double _Y2;
        private int _strokeThickness = 3;
        private Brush _stroke = Brushes.Black;
        private DoubleCollection _strokeDashArray = new DoubleCollection() {  1.0, 0.0  };
        public double X1 { get { return _X1; } set { if (_X1 != value) { _X1 = value; NotifyPropertyChanged("X1"); } } }
        public double X2 { get { return _X2; } set { if (_X2 != value) { _X2 = value; NotifyPropertyChanged("X2"); } } }
        public double Y1 { get { return _Y1; } set { if (_Y1 != value) { _Y1 = value; NotifyPropertyChanged("Y1"); } } }
        public double Y2 { get { return _Y2; } set { if (_Y2 != value) { _Y2 = value; NotifyPropertyChanged("Y2"); } } }
        public int StrokeThickness { get { return _strokeThickness; } set { if (_strokeThickness != value) { _strokeThickness = value; NotifyPropertyChanged("StrokeThickness"); } } }
        public Brush Stroke { get { return _stroke; } set { if (_stroke != value) { _stroke = value; NotifyPropertyChanged("Stroke"); } } }
        public DoubleCollection StrokeDashArray { get { return _strokeDashArray; } set { if (_strokeDashArray != value) { _strokeDashArray = value; NotifyPropertyChanged("StrokeDashArray"); } } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
