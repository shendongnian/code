            public class MeasurePoint : IDataPointProvider
        {
            public MeasurePoint(double x, double y, double scale)
            {
                X = x; Y = y; Scale = scale;
            }
            public double X { get; set; }
            public double Y { get; set; }
            public double Scale { get; set; }
            public DataPoint GetDataPoint()
            {
                return new DataPoint(X, Y);
            }
        }
