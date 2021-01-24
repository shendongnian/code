    List<object> results = new List<object>();
    
    private void DoLongTaskAsync()
    {
       object result = null;
       /*
        Do HttpRequest, etc.
       */
    
       lock (results)
       {
            results.Add(result);
       }
    }
