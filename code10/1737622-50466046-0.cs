    await StoreColorAsync(db, red);
    await db.InsertWithChildrenAsync(pers1, false);
    
    public async Task StoreColorAsync(SQLiteAsyncConnection db, Color color)
    {
    	if (color == null)
    		return;
    
    	var foundItem = await GetColorAsync(db, color.Code);
    	if (foundItem != null)
    	{
    		await db.UpdateAsync(color);
    	}
    	else
    	{
    		await db.InsertAsync(color);
    	}
    }
    
    public async Task<Color> GetColorAsync(SQLiteAsyncConnection db, string colorCode)
    {
    	var queryResult = await db.Table<Color>().Where(c => c.Code == colorCode).CountAsync();
    	if (queryResult > 0)
    	{
    		return await db.GetAsync<Color>(colorCode);
    	}
    	else
    	{
    		return null;
    	}
    }
