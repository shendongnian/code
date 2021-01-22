    int maxBufferCap = 500;
    BlockingCollection<MagicalObject> Collection 
                               = new BlockingCollection<MagicalObject>(maxBufferCap);
    void Producer()
    {
        while (magic.HasMoreMagic)
        {
            this.Collection.Add(magic.ProduceMagic());
        }
        this.Collection.CompleteAdding();
    }
    void Consumer()
    {
        foreach (MagicalObject magicalObject in this.Collection.GetConsumingEnumerable())
        {
            DoSomthing(magicalObject);
        }
    }
