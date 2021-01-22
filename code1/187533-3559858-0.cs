    private double _avg_count;
    static readonly object avgLock = new object();
    public double time { get; internal set; }
    public double count { get; internal set; }
    
    
    public double average_count {
        get 
        {
            return _avg_count;
        }
 
    }
    private void setAverageCount()
    {
        _avg_count = time == 0 ? 0 : (count / time);
    }
     public void Increment()
     {
         lock (avgLock)
         {
             count += 1;
             setAverageCount();
         }
            
     }
  
     public void EndTime(double time)
     {
         lock (avgLock)
         {
             time = time;
             setAverageCount();
             
         }
     }
