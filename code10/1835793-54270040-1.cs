    // Here I change the return value to IEnumerable
    public async Task<ActionResult<IEnumerable<Country>>> GetCountryRes()
    {
        var x =await ObjRepo.GetCountries();    
        return x;
    }
