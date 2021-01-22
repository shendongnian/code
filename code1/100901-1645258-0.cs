    interface CatalogRepository
    {
        Catalog FindByID(int ID);
    }
    
    interface CatalogImageRepository
    {
        CatalogImage FindByID(int ID);
    }
