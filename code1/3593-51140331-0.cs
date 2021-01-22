    public class DataPoint<T1,T2>
    {
        public DataPoint(T1 x, T2 y)
        {
            X = x;
            Y = y;
        }
        [JsonProperty("x")]
        public T1 X { get; }
        [JsonProperty("y")]
        public T2 Y { get; }
    }
    public class Trendline
    {
        public Trendline(IEnumerable<DataPoint<long, decimal>> dataPoints)
        {
            int count = 0;
            long sumX = 0;
            long sumX2 = 0;
            decimal sumY = 0;
            decimal sumXY = 0;
            foreach (var dataPoint in dataPoints)
            {
                count++;
                sumX += dataPoint.X;
                sumX2 += dataPoint.X * dataPoint.X;
                sumY += dataPoint.Y;
                sumXY += dataPoint.X * dataPoint.Y;
            }
            Slope = (sumXY - ((sumX * sumY) / count)) / (sumX2 - ((sumX * sumX) / count));
            Intercept = (sumY / count) - (Slope * (sumX / count));
        }
        public decimal Slope { get; private set; }
        public decimal Intercept { get; private set; }
        public decimal Start { get; private set; }
        public decimal End { get; private set; }
        public decimal GetYValue(decimal xValue)
        {
            return Slope * xValue + Intercept;
        }
    }
