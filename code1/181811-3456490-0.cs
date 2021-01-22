    public IList<FlattenedCategory> GetFlattenedCategories()
    {
        string sql = "SELECT categoryID, categoryName, parentID FROM category";
        SqlConnection cn = // open connection dataReader etc. (snip)
    
        while (sdr.Read())
        {
            FlattenedCategory cat = new FlattenedCategory();
            // fill in props, add the 'flattenedCategories' collection (snip)
        }
    
        return flattenedCategories;
    }
