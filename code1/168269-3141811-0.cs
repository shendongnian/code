    int maxBufferCap = 500;
    System.Collections.Concurrent.BlockingCollection<MagicalObject> Collection = new System.Collections.Concurrent.BlockingCollection<MagicalObject>(maxBufferCap);
    void Producer()
    {
        while (magic.HasMoreMagic)
        {
            Collection.Add(magic.ProduceMagic());
        }
        Collection.CompleteAdding();
    }
    void Consumer()
    {
        foreach (MagicalObject o in Collection.GetConsumingEnumerable())
        {
            DoSomthing(o);
        }
    }
