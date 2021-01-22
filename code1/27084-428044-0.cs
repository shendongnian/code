    try
    {
      // Do some work
    }
    catch (Exception ex)
    {
      if (ex is SoapException)
      {
        // SoapException specific recovery actions
      }
      else if (ex is HttpException)
      {
        // HttpException specific recovery actions
      }
      else if (ex is WebException)
      {
        // WebException specific recoery actions
      }
      else
      {
        throw;
      }
    }
