    public List<Event> Delete { get; set; }
    [XMLIgnore]
    public bool DeleteSpecified
    {
     get
     {
       bool isRendered = false;
       if (Delete != null)
       {
         isRendered = (Delete.Count > 0);
       } 
    
       return isRendered;
     }
     set
     {
     }
    }
