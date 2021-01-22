    public IEnumerable<SystemSalesTaxList> Get_SystemSalesTaxList()
    {
        return db.SystemSalesTaxLists;
    }
    public SystemSalesTaxList Get_SystemSalesTaxList(string salesTaxID)
    {
        return db.SystemSalesTaxLists.FirstOrDefault(s => s.SalesTaxID==salesTaxID);
    }
    public SystemSalesTaxList Get_SystemSalesTaxListByZipCode(string zipCode)
    {
        return db.SystemSalesTaxLists.FirstOrDefault(s => s.ZipCode == zipCode);
    }
