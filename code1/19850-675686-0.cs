    public class OverrideCursor : IDisposable
    {
    
      public OverrideCursor(Cursor changeToCursor)
      {
        Mouse.OverrideCursor = changeToCursor;
      }
    
      #region IDisposable Members
    
      public void Dispose()
      {
        Mouse.OverrideCursor = null;
      }
    
      #endregion
    }
