    public DataSet GetProductsInCategory(int Category) 
    {
    Database db = base.GetDatabase(); 
    DbCommand dbCommand = db.GetStoredProcComman("GetProductsByCategory"); 
    db.AddInParameter(dbCommand, "CategoryID", DbType.Int32, Category); 
    return db.ExecuteDataSet(dbCommand);
    } 
