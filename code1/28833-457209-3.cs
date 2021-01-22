    [OnDeserialized]
    public void OnDeserialization(StreamingContext context)
    {
    	Dictionary.OnDeserialization(this);
    	TestsLengthsOfDataStructures(this);
    }
