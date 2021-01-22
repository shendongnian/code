    private delegate void AddMessageToConsole_DELEGATE (frmMainPresenter.PresenterMessages message); 
    private void AddMessageToConsole (frmMainPresenter.PresenterMessages message) 
    { 
      if (InvokeRequired) 
      {
        // Invoke the target method, capturing the exception.
        Exception ex = null;
        Invoke((MethodInvoker)() =>
        {
           try
           {
             AddMessageToConsole(message);
           }
           catch (Exception error)
           {
             ex = error;
           }
        });
        // Handle error if it was thrown
        if (ex != null)
        {
          MSASession.ErrorLogger.Log(ex);
          // Rethrow, preserving exception stack
          throw ex.PrepareForRethrow();
        }
      } 
      else 
      { 
        string message_text = ""; //Message that will be displayed in the Console / written in the Log. 
        try 
        { 
          message_text = I18N.GetTranslatedText(message) 
        } 
        catch (Exception ex) 
        { 
          throw new Exception(ex.Message, ex); 
        } 
 
        txtConsole.AppendText(message_text); 
      } 
    } 
