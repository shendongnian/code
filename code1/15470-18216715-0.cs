    [Test]
    public void Test_Notify_Property_Changed_Fired()
    {
    	var p = new Project();
    
    	var tracer = new INCPTracer();
    
    	// One event
    	tracer.With(p).CheckThat(() => p.Active = true).RaisedEvent(() => p.Active);
    
    	// Two events in exact order
    	tracer.With(p).CheckThat(() => p.Path = "test").RaisedEvent(() => p.Path).RaisedEvent(() => p.Active);
    }
