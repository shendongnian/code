    private void releaseObject(object obj)
    {
      try
      {
          System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
          obj = null;
      }
      catch (Exception ex)
      {
          //TODO
      }
      finally
      {
         GC.Collect();
      }
    }
