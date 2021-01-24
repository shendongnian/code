    public async Task<ActionResult<List<DashBoar>>> GetAllAsync()
    {
         var x = await _Repo.GetPetsAsync();
         return x;
    }
