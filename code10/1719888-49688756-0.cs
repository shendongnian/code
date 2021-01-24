    #if RONGTENVERSION_1_5_PLUS
    public string[] ExtendedInfo()
    {
        return this.api.ExtendedInfo;
    }
    #elif RONGTENVERSION_1_2
    public string[] ExtendedInfo()
    {
        return new string[] { "not available" };
    }
    #elif RONGTENVERSION_1_1_MIN
    public string ExtendedInfo()
    { 
        return "not available";
    }
    #endif
