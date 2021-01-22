    public abstract class TimeSeries<TS> where TS : AbstractTimeSeries<TS> 
     { public abstract TS Slice(); 
     }
    public class GenericTimeSeries<T> :  TimeSeries<GenericTimeSeries<T>> 
     { public override GenericTimeSeries<T> Slice() {}  
     }
 
    public class TimeSeriesDouble :  TimeSeries<TimeSeriesDouble> 
     { public override TimeSeriesDouble Slice() {}  
     }
