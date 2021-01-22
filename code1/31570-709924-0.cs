    Old Style Code
    
    object obj;
    
    try
    {
       obj= new object();
       //Do something with the object
    }
    catch
    {
       //Handle Exception
    }
    finally
    {
      
      if (obj != null)
      {  
         obj.Dispose();
      }
    }  
    
    Newer Style Code
    
    try
    {   
      using (object obj = new object())
      {
         //Do something with the object
      }
    catch
    {
       //Handle Exception
    }
