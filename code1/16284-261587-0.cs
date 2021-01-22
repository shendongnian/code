    try
    {
        DoSomething();
    }
    catch ( Exception ex )
    { 
       throw new FaultException<CustomException>( new CustomException( ex ), ex.Message );
    }
    
