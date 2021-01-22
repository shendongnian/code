    public class TimeSeries<T, U> where U : TimeSeries<T, U>
    {
        U Slice(...)
    }
    public class TimeSeriesDouble : TimeSeries<double, TimeSeriesDouble>
    {
        ...
    }
