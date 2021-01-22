    [WebMethod( EnableSession = true )] 
    public void InsertIntoSessionMethodName( string value1, string value2, string value3 )
    {
    	
    	Session[ "value1" ] = value1;
    	Session[ "value2" ] = value2;
    	Session[ "value2" ] = value3;
    }
