    public class SurfaceLoad : Load, INotifyPropertyChanged
    {
            private double force;
            public double Force
            {
                get { return force; }
                set
                {
                    force = value;
                    NotifyPropertyChanged("Force");
                }
            }
            public SurfaceLoad(double f)
            {
                Force = f;
            }
            public SurfaceLoad()
            {
                Force = 0.0;
            }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void NotifyPropertyChanged(string propertyName)
    {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
    }
    protected void NotifyPropertyChanged<T>(Expression<Func<T>> propertySelector)
    {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                string propertyName = GetPropertyName(propertySelector);
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    }
