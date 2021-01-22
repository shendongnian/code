    private Dictionary<string, Thingey> Thingeys;
    public Thingey GetThingey(Request request)
    {
        string thingeyName = request.ThingeyName;
        if (!this.Thingeys.ContainsKey(thingeyName))
        {
            lock (this.Thingeys)
            {
                this.Thingeys.Add(thingeyName, null);
                if (!this.Thingeys.ContainsKey(thingeyName))
                {
                    // create a new thingey on 1st reference
                    Thingey newThingey = new Thingey(request);
                    Thingeys[thingeyName] = newThingey;
                }
                // else - oops someone else beat us to it
                // but it doesn't mather anymore since we only created one Thingey
            }
        }
        return this.Thingeys[thingeyName];
    }
