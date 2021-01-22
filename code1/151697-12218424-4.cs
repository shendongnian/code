    public GenericResult CanDivideNumber(int a, int b)
    {
    	GenericResult result = new GenericResult();
    
    	try
    	{
    		result.Value = a / b;
    	}
    	catch (Exception ex)
    	{
    		result.AddError(ex.ToString());
    	}
    
    	return result;
    }
