    public  List<BrokenBusinessRule> GetBrokenRules()
    {
        var brokenRules = new List<BrokenBusinessRule>(); 
       // null is not possible because Campus is supplied in the constructor
       if (!Campus.Any())
            brokenRules.Add(new BrokenBusinessRule("Facility Campus", "Must have at least one Campus"));
       else
       {
           foreach(var campus in  Campus)
           {
               brokenRules.AddRange(campus.GetBrokenRules());
           }
       }
       
       if (!Building,Any())
            brokenRules.Add(new BrokenBusinessRule("Facility Building", "Must have at least one Building"));
        else
        {
            foreach(var building in Building)
            {
                brokenRules.AddRange(building.GetBrokenRules());
            }
        }
        if (!Floor.Any())
            brokenRules.Add(new BrokenBusinessRule("Facility Floor", "Must have at least one Floor"));
        else
        {
            foreach (var floor in Floor)
            {
                brokenRules.AddRange(floor.GetBrokenRules());
            }        
        }
        return brokenRules;     
    }
