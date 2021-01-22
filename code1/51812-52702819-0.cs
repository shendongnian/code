     public DateTime ModifiedAt
    	    {
    		    get => _modifiedAt;
    		    set => _modifiedAt = value.AddTicks(-(value.Ticks % TimeSpan.TicksPerMillisecond));
    	    }
 
