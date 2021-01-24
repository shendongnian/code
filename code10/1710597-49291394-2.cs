    try
    {
      // load the assembly or type
    }
    catch (Exception ex)
    {
      foreach (var item in ex.LoaderExceptions)
      {
          MessageBox.Show(item.Message);                    
      }
      if (ex is System.Reflection.ReflectionTypeLoadException)
      {
        var typeLoadException = ex as ReflectionTypeLoadException;
        var loaderExceptions  = typeLoadException.LoaderExceptions;
      }
    }
