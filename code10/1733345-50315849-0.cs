    static PerformanceCounter _requestCounter; // keep instance around
    static PerformanceCounter cpuCounter  // property with lazy init
    {
       get 
       {
          // initialize if we haven't done so.
          if (_requestCounter == null) {
            var cat = PerformanceCounterCategory.GetCategories().FirstOrDefault(s => s.CategoryName.Contains("ASP.NET Apps v4.0.30319"));
            var catinstances = cat.GetInstanceNames().First(s => s.ToUpper().Contains("_WEB"));
            _requestCounter = new PerformanceCounter("ASP.NET Apps v4.0.30319", "Requests/Sec", catinstances, true);
            
          }
          return _requestCounter;
       }
    }
    
    public static int GetRequest()
    {  
        return unchecked((int)cpuCounter.NextValue());
    }
