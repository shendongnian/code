    private Dictionary<string, Thingey> Thingeys;
    // An immutable list of (most of) the thingeys that have been created.
    private string[] existingThingeys;
    public Thingey GetThingey(Request request)
    {
        string thingeyName = request.ThingeyName;
        // Reference the same list throughout the method, just in case another
        // thread replaces the global reference between operations.
        string[] localThingyList = existingThingeys;
        // Check to see if we already made this Thingey. (This might miss some, 
        // but it doesn't matter.
        // This operation on an immutable array is thread-safe.
        if (localThingyList.Contains(thingeyName))
        {
            // But referencing the dictionary is not thread-safe.
            lock (this.Thingeys)
            {
                if (this.Thingeys.ContainsKey(thingeyName))
                    return this.Thingeys[thingeyName];
            }
        }
        Thingey newThingey = new Thingey(request);
        Thiney ret;
        // We haven't locked anything at this point, but we have created a new 
        // Thingey that we probably needed.
        lock (this.Thingeys)
        {
            // If it turns out that the Thingey was already there, then 
            // return the old one.
            if (!Thingeys.TryGetValue(thingeyName, out ret))
            {
                // Otherwise, add the new one.
                Thingeys.Add(thingeyName, newThingey);
                ret = newThingey;
            }
        }
        // Update our existingThingeys array atomically.
        string[] newThingyList = new string[localThingyList.Length + 1];
        Array.Copy(localThingyList, newThingey, localThingyList.Length);
        newThingey[localThingyList.Length] = thingeyName;
        existingThingeys = newThingyList; // Voila!
        return ret;
    }
