    private DateTime ExecutableInfo()
    {
      System.IO.FileInfo fi = new System.IO.FileInfo(Application.ExecutablePath.Trim());
      try
      {
        return fi.CreationTime;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        fi = null;
      }
    }
