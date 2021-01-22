    namespace MyCLRNamespace
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                Polygon MyPolygon = new Polygon();
                MyPolygon.Points = new PointCollection {    new Point(100, 0),
                                                            new Point(200, 200),
                                                            new Point(0, 200)   };
                //if (MyPolygon.IsMeasureValid == false)
                    MyPolygon.Measure(new Size( double.PositiveInfinity,
                                                double.PositiveInfinity));
                double PolyWidth = MyPolygon.DesiredSize.Width;
            }
        }
    }
