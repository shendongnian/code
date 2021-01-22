      public class Busy : IDisposable
      {
    
        private Cursor _oldCursor;
    
        private Busy()
        {
          _oldCursor = Cursor.Current;
        }
    
        public static Busy WaitCursor
        {
          get
          {
            Cursor.Current = Cursors.WaitCursor;
            return new Busy();
          }
        }
        
        #region IDisposable Members
    
        public void Dispose()
        {
          Cursor.Current = _oldCursor;
        }
    
        #endregion
      }
