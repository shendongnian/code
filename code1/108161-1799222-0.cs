    private Dictionary<string, Thingey> Thingeys;
    private string[] existingThingeys;
    public Thingey GetThingey(Request request)
    {
        string thingeyName = request.ThingeyName;
        string[] localThingyList = existingThingeys;
        if (localThingyList.Contains(thingeyName))
        {
            lock (this.Thingeys)
            {
                if (this.Thingeys.ContainsKey(thingeyName))
                    return this.Thingeys[thingeyName];
            }
        }
        Thingey newThingey = new Thingey(request);
        Thiney ret;
        lock (this.Thingeys)
        {
            if (!Thingeys.TryGetValue(request.ThingeyName, out ret))
                Thingeys.Add(request.ThingeyName, newThingey);
            else
                ret = newThingey;
        }
        string[] newThingyList = new string[localThingyList.Length + 1];
        Array.Copy(localThingyList, newThingey, localThingyList.Length);
        newThingey[localThingyList.Length] = newThingey;
        existingThingeys = newThingyList;
        return ret;
    }
