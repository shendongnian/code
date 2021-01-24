    public class PortionPath : Shape
    {
        #region Geometry
        private static readonly DependencyProperty GeometryProperty =
            DependencyProperty.Register("Geometry", typeof(Geometry), typeof(PortionPath),
                new PropertyMetadata(Geometry.Empty, null, CoerceGeometry));
        private Geometry Geometry => (Geometry)GetValue(GeometryProperty);
        private static object CoerceGeometry(DependencyObject d, object baseValue)
        {
            PortionPath portionPath = (PortionPath) d;
            int firstPoint = (int)(portionPath.PointCollection.Length * portionPath.From);
            int lastPoint = (int)(portionPath.PointCollection.Length * portionPath.To);
            if (firstPoint == 0 && lastPoint == portionPath.PointCollection.Length)
            {
                return portionPath.Data;
            }
            if (firstPoint == lastPoint)
            {
                return Geometry.Empty;
            }
            PathFigure pathFigure = new PathFigure();
            var pointCollection = portionPath.PointCollection.Skip(firstPoint).Take(lastPoint - firstPoint).ToArray();
            if (pointCollection.Length > 0)
            {
                pathFigure.StartPoint = pointCollection[0];
                if (pointCollection.Length > 1)
                {
                    Point[] array = new Point[pointCollection.Length - 1];
                    for (int i = 1; i < pointCollection.Length; i++)
                    {
                        array[i - 1] = pointCollection[i];
                    }
                    pathFigure.Segments.Add(new PolyLineSegment(array, true));
                }
            }
            PathGeometry polylineGeometry = new PathGeometry();
            polylineGeometry.Figures.Add(pathFigure);
            return polylineGeometry;
        }
        #endregion
        #region PointCollection
        private static readonly DependencyProperty PointCollectionProperty =
            DependencyProperty.Register("PointCollection", typeof(Point[]), typeof(PortionPath),
                new PropertyMetadata(new Point[0], PointCollectionChanged, CoercePointCollection));
        private Point[] PointCollection => (Point[]) GetValue(PointCollectionProperty);
        private static void PointCollectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(GeometryProperty);
        }
        private static object CoercePointCollection(DependencyObject d, object baseValue)
        {
            PortionPath portionPath = (PortionPath) d;
            var path = portionPath.Data;
            var steps = portionPath.Steps;
            var g = path.GetFlattenedPathGeometry(portionPath.Tolerance, ToleranceType.Absolute);
            List<Point> pointCollection = new List<Point>();
            var step = 1.0 / steps;
            for (double i = 0; i <= 1; i += step)
            {
                g.GetPointAtFractionLength(i, out Point p, out _);
                pointCollection.Add(p);
            }
            return pointCollection.ToArray();
        }
        #endregion
        #region Tolerance
        private static readonly DependencyProperty ToleranceProperty =
            DependencyProperty.Register("Tolerance", typeof(double), typeof(PortionPath),
                new PropertyMetadata(0.000001, ToleranceChanged));
        public double Tolerance
        {
            get => (double) GetValue(ToleranceProperty);
            set => SetValue(ToleranceProperty,value);
        }
        private static void ToleranceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(PointCollectionProperty);
        }
        #endregion
        #region Data
        public static DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(Geometry),
            typeof(PortionPath), new FrameworkPropertyMetadata(Geometry.Empty, FrameworkPropertyMetadataOptions.AffectsRender, DataChanged));
        public Geometry Data
        {
            get => (Geometry)GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }
        private static void DataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(PointCollectionProperty);
        }
        #endregion
        #region Steps
        public static DependencyProperty StepsProperty = DependencyProperty.Register("Steps", typeof(int),
            typeof(PortionPath), new FrameworkPropertyMetadata(1000, FrameworkPropertyMetadataOptions.AffectsRender, StepsChanged));
        public int Steps
        {
            get => (int)GetValue(StepsProperty);
            set => SetValue(StepsProperty, value);
        }
        private static void StepsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(PointCollectionProperty);
        }
        #endregion
        #region From
        public static DependencyProperty FromProperty = DependencyProperty.Register("From", typeof(double),
            typeof(PortionPath), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender, FromChanged, CoerceFrom));
        public double From
        {
            get => (double)GetValue(FromProperty);
            set => SetValue(FromProperty, value);
        }
        private static void FromChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(ToProperty);
            d.CoerceValue(GeometryProperty);
        }
        private static object CoerceFrom(DependencyObject d, object baseValue)
        {
            switch (baseValue)
            {
                case double doubleValue:
                    if (doubleValue > 1.0) return 1.0;
                    if (doubleValue < 0.0) return 0.0;
                    return doubleValue;
                default:
                    return 1.0;
            }
        }
        #endregion
        #region To
        public static DependencyProperty ToProperty = DependencyProperty.Register("To", typeof(double),
            typeof(PortionPath), new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender, ToChanged, CoerceTo));
        public double To
        {
            get => (double) GetValue(ToProperty);
            set => SetValue(ToProperty,value);
        }
        private static void ToChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(GeometryProperty);
        }
        private static object CoerceTo(DependencyObject d, object baseValue)
        {
            PortionPath portionPath = (PortionPath) d;
            switch (baseValue)
            {
                case double doubleValue:
                    if (doubleValue > 1.0) return 1.0;
                    if (doubleValue < 0.0 || doubleValue < portionPath.From) return portionPath.From;
                    return doubleValue;
                default:
                    return 1.0;
            }
        }
        #endregion
        protected override Geometry DefiningGeometry => Geometry;
    }
