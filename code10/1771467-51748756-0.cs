    [HttpGet]
    public async Task<Category> Get(int id)
    {
        return await this.categoryDataProvider.GetCategory(Category_ID);
    }
