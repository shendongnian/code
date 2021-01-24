    public void ProcessReading(IReading reading)
    {
        if (reading == null)
            return null;
    
		try
		{
			var castReading = (ILocation) reading; 
			// Process location
		}
		catch
		{
			//exception hit
		}
		try
		{
			var castReading = (IMobilityProfile ) reading; 
			// Process mobility profile
		}
		catch
		{
			//exception hit
		}
		try
		{
			var castReading = (ITrip ) reading; 
			// Process trip
		}
		catch
		{
			//exception hit
		}
    }
    
