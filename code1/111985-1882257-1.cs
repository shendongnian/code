    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    public bool Equals(string value)
    {
        if ((value == null) && (this != null))
        {
            return false;
        }
        return EqualsHelper(this, value);
    }
