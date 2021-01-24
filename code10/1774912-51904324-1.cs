    public class NotifyingPoint : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged([CallerMemberName] string caller = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
            }
    
            public event EventHandler ValueChanged;
    
            private double _x = 0.0;
            public double X
            {
                get { return _x; }
                set
                {
                    _x = value;
                    OnPropertyChanged();
                    ValueChanged?.Invoke(this, null);
                }
            }
    
            private double _y = 0.0;
            public double Y
            {
                get { return _y; }
                set
                {
                    _y = value;
                    OnPropertyChanged();
                }
            }
    
            public NotifyingPoint()
            {
            }
    
            public NotifyingPoint(double x, double y)
            {
                X = x;
                Y = y;
            }
    
            public Point ToPoint()
            {
                return new Point(_x, _y);
            }
        }
