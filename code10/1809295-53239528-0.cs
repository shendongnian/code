    public class MovingAverage
    {
        DateTime Date { get; set; }
        decimal Close { get; set; }
        public MovingAverage(DateTime date, decimal close) 
        {
            Date = date;
            Close = close;
        }
    }
