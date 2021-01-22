    try
    {
       //divide user imputs
    }
    catch(DivideByZeroException)
    {
      // tell user bad inputs ect....
    }
    catch (Exception e)
    {
        //If you choose to throw the exception you should
        //***********************
        throw; 
        //VS
        throw ex; //Throw ex will restart the stack trace  
        // recover
    }
    finally
    {
        //Clean up resources and continue
    }
