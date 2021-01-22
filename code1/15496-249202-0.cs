    class C
    {
      // Don't to expose this publicly so that 
      // no one can get behind your back and change 
      // anything
      private List<W> contentsW; 
    
      public void Add(W theW)
      {
        theW.Container = this;
      }
    
      public void Remove(W theW)
      {
        theW.Container = null;
      }
    
      #region Only to be used by W
      internal void RemoveW(W theW)
      {
        contentsW.Remove(theW);
      }
    
      internal void AddW(W theW)
      {
        if (!contentW.Contains(theW))
          contentsW.Add(theW);
      }
      #endregion
    }
    
    class W
    {
      private C containerC;
      
      public Container Container
      {
        get { return containerC; }
        set 
        { 
          if (containerC != null)
            containerC.RemoveW(this);
          containerC = value; 
          if (containerC != null)
            containerC.AddW(this);
        }
      }
    }
