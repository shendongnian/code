      try
      {
          this.InvokeMarshaledCallback(tme);
      }
      catch (Exception exception)
      {
          tme.exception = exception.GetBaseException();
      }
      ...
           if ((!NativeWindow.WndProcShouldBeDebuggable && (tme.exception != null)) && !tme.synchronous)
           {
               Application.OnThreadException(tme.exception);
           }
