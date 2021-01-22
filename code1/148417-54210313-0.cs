    protected override void OnStop()
    {
        try
        {
            EventLog.WriteEntry("MyService", "Service is going to stop because of ...", EventLogEntryType.Information);        
            // Dispose all your objects here        
        }
        catch (Exception ex)
        {
            EventLog.WriteEntry("MyService", "Exception : " + ex.ToString(), EventLogEntryType.Error);                
        }
        finally
        {
    	    GC.Collect();                
            base.OnStop();
        }
    }
