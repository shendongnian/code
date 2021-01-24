    You can use different approach for foreach , which is better than above, also code could minimised bit.
    foreach (Medicine medicine in medicineList)
                {
                    DoctorsOrderViewModel vm = new DoctorsOrderViewModel()
                    {
                        DrugID = x.PKID,
                        Name = x.Name,
                        DrugName = x.Name,
                        UnitName = x.UnitName,
                        CategoryID = x.CategoryID,
                        CategoryName = x.CategoryName,
                        DosageFormID = x.DosageFormID,
                        InventoryTypeID = x.InventoryTypeID,
                    };
    
                    temp.Add(vm);
                    this.DrugItemsComboForSearch.Add(vm);
    
    
    
    
                    if (!this.MedicineCategoryItemsCombo.Select(y => y.CategoryID == 
                        x.CategoryID).Any())
                    {
                        this.MedicineCategoryItemsCombo.Add(new DoctorsOrderViewModel()
                        {
                            CategoryID = x.CategoryID,
                            CategoryName = x.CategoryName,
                        };);
                    }
                }
