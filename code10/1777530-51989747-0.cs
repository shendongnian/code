    private string city;
    public string City
    {
        get { return city; }
        set { city = RemoveSpecialCharacters(value); }
    }
