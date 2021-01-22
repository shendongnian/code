    public void Add(Creature c, Point at)
    {
        IList<Creature> list;
        if (!theWorld.TryGetValue(at)) {
            list = theWorld[at] = new List<Creature>();
        }
        list.Add(c);
    }
