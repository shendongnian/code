    private class ErrorTracker {
      private HashSet<Control> mErrors = new HashSet<Control>();
      private ErrorProvider mProvider;
      public ErrorTracker(ErrorProvider provider) { 
        mProvider = provider; 
      }
      public void SetError(Control ctl, string text) {
        if (string.IsNullOrEmpty(text)) mErrors.Remove(ctl);
        else mErrors.Add(ctl);
        mProvider.SetError(ctl, text);
      }
      public int Count { get { return mErrors.Count; } }
    }
