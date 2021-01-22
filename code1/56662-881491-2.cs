    try
    {
       ...
    }
    catch(SQLException sex)
    {
       //Do Custom Logging 
    }
    catch(OtherException oex)
    {
       //Do something else
    }
    catch
    {
       throw; //Chuck everything else back up the stack
    }
