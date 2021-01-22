    foreach (string aDll in dllCollection) 
    {
      try 
      {
         Assembly anAssembly = Assembly.LoadFrom(aDll);
      }
      catch (BadImageFormatException ex)
      {
        //Handle this here
      }
      catch (Exception ex)
      {
        //Other exceptions (i/o, security etc.)
       }
    }
