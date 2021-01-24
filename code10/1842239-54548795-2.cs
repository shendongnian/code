    public void check(string Name, int? ID)
    {
        var tableNameCheck1= IsProductNameExist(_dbContext.SubCategories, Name, ID);
        var tableNameCheck2= IsProductNameExist(_dbContext.Categories, Name, ID);       
    }
