    private readonly object thingeysLock = new object();
    private readonly Dictionary<string, Thingey> thingeys;
    public Thingey GetThingey(Request request)
    {
        string key = request.ThingeyName;
        lock (thingeysLock)
        {
            Thingey ret;
            if (!thingeys.TryGetValue(key, out ret))
            {
                ret = new Thingey(request);
                thingeys[key] = ret;
            }
            return ret;
        }
    }
