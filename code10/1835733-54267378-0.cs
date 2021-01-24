    [HttpGet("{id}")]
    public async Task<DataStoreQuery> GetByIdAsync(int id)
    {
        try
        {
            return await _dataStoreService.GetByIdAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
