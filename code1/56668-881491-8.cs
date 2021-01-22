    try
    {
       ...
    }
    catch(SQLException sex)
    {
       //Do Custom Logging 
       //Don't throw exception - swallow it here
    }
    catch(OtherException oex)
    {
       //Do something else
       throw new WrappedException("Other Exception occured");
    }
    catch
    {
       System.Diagnostics.Debug.WriteLine("Eeep! an error, not to worry, will be handled higher up the call stack");
       throw; //Chuck everything else back up the stack
    }
