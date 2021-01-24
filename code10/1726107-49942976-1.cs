    public void ProcessReading(IReading reading)
    {
        if (reading == null)
            return null;
    
    	if((reading as ILocation) != null)
    	{
    		// Process location
    	}
    	else if((reading as IMobilityProfile) != null)
    	{
    		// Process mobility profile
    	}
    	else if((reading as ITrip) != null)
    	{
    		// Process trip
    	}
    	else
    	{
    		throw new NotSupportedException($"Processing the type '{reading.GetType().FullName}' is not supported.");
    	}
    }
