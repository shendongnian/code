     try
     {
         ....
     }
     catch (Exception ex)
     {
         this.Session["exceptionMessage"] = ex.Message;
         Response.Redirect( "ErrorDisplay.aspx" );
         log.Write( ex.Message  + ex.StackTrace );
     }
