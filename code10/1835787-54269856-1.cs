    public async Task<ActionResult<Country[]>> GetCountryRes()
    {
        var x = await ObjRepo.GetCountries();    
        return x.ToArray();
    }
