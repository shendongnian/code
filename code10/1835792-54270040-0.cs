    public async Task<IEnumerable<Country>> GetCountries()
    {
        var x = from n in _ConnectToDb.Country
                orderby n.CountryId
                select n;
        return await Task.FromResult(x.ToList());
    }
    // I prefer this version 
    public Task<IEnumerable<Country>> GetCountries2()
    {
        var x = from n in _ConnectToDb.Country
            orderby n.CountryId
            select n;
        return Task.FromResult(x.ToList().AsEnumerable());
    }
