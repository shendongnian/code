    public Thingey GetThingey(Request request)
    {
        string thingeyName = request.ThingeyName;
        Thingey output;
        
        lock (this.Thingeys)
        {
            if(!this.Thingeys.TryGetValue(thingeyName, out output))
            {
                output = new Thingey(request);
                this.Thingeys.Add(thingeyName, newThingey);
            }
        }
        return output;
    }
