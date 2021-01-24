    public ActionResult Save(SupplierandCategoryViewModel Supply)
    {
    
        var DSupply = new Supplier()
        {
            SupplierName = Supply.SupplierModel.SupplierName,
            SupplierCode = Supply.SupplierModel.SupplierCode,
            SupplierContact = Supply.SupplierModel.SupplierContact,
            CategoryId = Supply.SelectedCategory                     <==Note here I assigned SelectedCategory to model's CategoryId
        };
    
        _SBC.Suppliers.Add(DSupply);
        _SBC.SaveChanges();
        return View();
    }
