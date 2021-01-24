    private string city;
    public string City
    {
        get { return RemoveSpecialCharacters(city); }
        set { city = value; }
    }
