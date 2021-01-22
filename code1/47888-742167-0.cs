    public TblUserCollection GetCollection()
    {
        TblUserCollection collection = new TblUserCollection();
        collection.Query.Where(collection.Query.CompanyId == CompanyId);
        collection.Query.OrderBy(collection.Query.FullName, esOrderByDirection.Ascending);
        collection.Query.Load();
        return collection;
    }
