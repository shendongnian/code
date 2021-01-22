    public abstract class TimeSeriesBase<TS> where TS : TimeSeriesBase<TS> 
     { public virtual TS Slice() { ... } 
     }
    public class TimeSeries<T> :  TimeSeriesBase<TimeSeries<T>> {}
 
    public class TimeSeriesDouble :  TimeSeries<TimeSeriesDouble> 
     { double Interpolate() { ... }
     }
