    public DateTime CurrentTime 
    {
        get 
        { 
           DateTime.TryParse(this.Schedule.TimeTables.Max(x => x.StartTime), out currentTime);
           
           // will return the old value if the parse failed.
           return currentTime;       
        } 
        set 
        { 
            currentTime = value; 
        }
    }
    private DateTime currentTime;
