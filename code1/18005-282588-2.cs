    public abstract class TimeSeriesBase<TS> where TS : TimeSeriesBase<TS> 
     { public TS Slice() { ... } 
     }
    public class TimeSeries<T> :  TimeSeriesBase<TimeSeries<T>> {}
 
    public class TimeSeriesDouble :  TimeSeriesBase<TimeSeriesDouble> 
     { public double Interpolate() { ... }
     }
