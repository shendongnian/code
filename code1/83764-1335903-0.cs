    #if USE_FLOAT
    public float OutputValue(object input)
    {
        return (float)input;
    }
    #endif
    #if USE_DOUBLE
    public double OutputValue(object input)
    {
        return (double)input;
    }
    #endif
and call OutputValue(1.5); to get it to convert it for you.
