    private readonly DefaultFlushEntityEventListener _impl = new DefaultFlushEntityEventListener();
    public void OnFlushEntity(FlushEntityEvent flushEntityEvent)
    {
       ... my code goeas here ... 
       _impl.OnFlushEntity(flushEntityEvent);
    }
        
