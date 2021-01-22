    public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, 
                                    int id, string format, params Object[] data)
    {
      base.WriteLine(String.Format(format, data));
    }
