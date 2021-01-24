    public async Task<List<Tenant>> GetTenants()
    {
        return await DocumentDBRepository<Tenant>.GetItemsAsync().ToList();
    }
 
