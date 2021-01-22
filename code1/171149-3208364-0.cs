    try
    {
      //Do your entity data thing in the page...
    }
    catch(ReflectionTypeLoadException rtle)
    {
      foreach(Exception ex in rtle.LoaderExceptions)
      {
        Debug.WriteLine(ex.ToString());
      }
    }
