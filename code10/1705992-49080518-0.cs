    Class Hero
    {
    Public String Name{get; set;}
    Public Double health;
    Public Double Health
    {
        get
        {
            return health;
            
        }
        set
        {
           //Here you can place a function which can easily check the value of health and work accordingly.
           
           ProgressBarColorChange(value+health);
           health = value;
        } 
     } 
     Public void ProgressBarColorChange(double health)
     {
       //Color Change Fuction Implementation
     }
    }
