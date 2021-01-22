    List<string> GetSlots(int duration)
    {
        var slots = new List<string>();
        int[] startTimes = new int[] { 8, 10, 12 }; // etc.
    
        foreach(int h in startTimes)
        {
            // assuming all start times are on the h:30 
            slots.Add(h + ":30 - " + (h + duration) + ":30"); 
        }
    
        return slots;
    }
