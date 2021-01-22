    private Dictionary<string, Thingey> Thingeys;
    public Thingey GetThingey(Request request)
    {
        string thingeyName = request.ThingeyName;
        if (!this.Thingeys.ContainsKey(thingeyName))
        {
            lock (this.Thingeys)
            {
                // only one can create the same Thingy
                Thingey newThingey = new Thingey(request);
                if (!this.Thingeys.ContainsKey(thingeyName))
                {
                    this.Thingeys.Add(thingeyName, newThingey);
                }
            }
        }
        return this. Thingeys[thingeyName];
    }
