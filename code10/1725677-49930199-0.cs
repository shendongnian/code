    namespace EventsPractice
    {
        class Program
        {
            static void Main(string[] args)
            {
                Point point = new Point();
    
                point.PointChanged += HandlePointChanged;
            }
            static public void HandlePointChanged(object sender, EventArgs eventArgs)
            {
                // Do something Here
            }
    
        }
        class Point
        {
            private double x;
            private double y;
    
            public double X
            {
                get { return x; }
                set
                {
                    x = value;
                    OnPointChanged();
                }
            }
            public double Y
            {
                get { return y; }
                set
                {
                    y = value;
                    OnPointChanged();
                }
    
            }
    
            public event EventHandler PointChanged;
    
            public void OnPointChanged()
            {
                if (PointChanged != null)
                    PointChanged(this, EventArgs.Empty);
            }
        }
    }
