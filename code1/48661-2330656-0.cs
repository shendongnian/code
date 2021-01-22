    // check for cached results
    object cachedResults = ctx.Cache["PersonList"];
    ArrayList results = new ArrayList();
    
    if  (cachedResults == null)
    {
      // lock this section of the code
      // while we populate the list
      lock(lockObject)
      {
        // only populate if list was not populated by
        // another thread while this thread was waiting
        if (cachedResults == null)
        {
          ...
        }
      }
    }
