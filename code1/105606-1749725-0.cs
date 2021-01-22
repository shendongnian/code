try
{   
    ...
}
catch (Exception exception)
{    
   MyLogger.Log(exception.Message);
   throw;
}
