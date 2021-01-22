    public int LimitToRange(int value, int inclusiveMinimum, int inlusiveMaximum)
    {
        if (value < inclusiveMinimum) { return inclusiveMinimum; }
        if (value > inlusiveMaximum) { return inlusiveMaximum; }
        return value;
    }
