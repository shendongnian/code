    [Test]
    public void testGetCityToSearch()
    {
        // if thecitytype = "City1", listingToSearch = 1
        // if thecitytype = "City2", listingToSearch = 2
        doParseCity(1, "City1");
        doParseCity(2, "City2");
        doParseCity(20, "City20");        
    }
    public void doParseCity(int expected, string input )
    {
        int listingsToSearch;
        string cityNum = input.Substring(4);
        bool parseResult = Int32.TryParse(cityNum, out listingsToSearch);
        Assert.IsTrue(parseResult);
        Assert.AreEqual(expected, listingsToSearch);
    }
