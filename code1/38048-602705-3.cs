    public void invokeFaultyCode()
    {
        try
        {
            DataTable dt = ReturnSomething();
        }
        catch(Exception e)
        {
            // Print the error message, cleanup, whatever
        }    
    }
    public DataTable ReturnSomething() throws Exception
    {
       try
       {  
          //logic here
         return ds.Tables[0];
       }
       catch (Exception e)
       {
          ErrorString=e.Message;
          throw;
       }
    }
