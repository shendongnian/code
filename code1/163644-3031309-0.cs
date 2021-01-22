    public void SomeClassInit(Guid docId, DateTime? addedOn = null)
    {
        if (!addedOn.HasValue)
            addedOn = DateTime.Now;
        //Init codes here
    }
