     var transformed = medicineList.Select(x =>
                             new DoctorsOrderViewModel()
                             {
                                 DrugID = x.PKID,
                                 Name = x.Name,
                                 DrugName = x.Name,
                                 UnitName = x.UnitName,
                                 CategoryID = x.CategoryID,
                                 CategoryName = x.CategoryName,
                                 DosageFormID = x.DosageFormID,
                                 InventoryTypeID = x.InventoryTypeID,
                             })
                             .ToList();
    temp.AddRange(transformed);
    this.DrugItemsComboForSearch.AddRange(transformed);                           
    (...)
