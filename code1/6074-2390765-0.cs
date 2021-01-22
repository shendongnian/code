    public string ActualProperty { get; set; }
    public string[] GetIndividualStrings()
    {
        return ActualProperty.Split(.....);
    }
    
    public void SetFromIndividualStrings(string[] values)
    {
        // join strings from array .... ;
    }
