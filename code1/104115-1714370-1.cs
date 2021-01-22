    public DateTime CurrentTime 
    {
        get 
        { 
           DateTime retVal;
           if(DateTime.TryParse(this.Schedule.TimeTables.Max(x => x.StartTime), out retVal))
           {
               currentTime = retVal;
           }
           
           // will return the old value if the parse failed.
           return currentTime;       
        } 
        set 
        { 
            currentTime = value; 
        }
    }
    private DateTime currentTime;
