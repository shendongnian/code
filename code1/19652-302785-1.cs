    public void DoThis(Something thing)
    {
        if (thing == null)
        {
            throw new ArgumentException("Arg [thing] cannot be null.");
        }
        //...
    }
