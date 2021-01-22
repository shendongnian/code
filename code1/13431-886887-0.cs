    try 
    {
    	CallTheCodeThatMightThrowException()
     }
    catch (Exception ex)
    {
    	System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace ();
    	Utils.ErrorHandler.Trap ( ref objUser, st, ex );
    } //eof catch
