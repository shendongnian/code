        public static List<(string catId, string catName)> MyWay(List<Medicine> medicineList)
        {
            var temp = new List<DoctorsOrderViewModel>();
            var DrugItemsComboForSearch = new List<DoctorsOrderViewModel>();
            var transformed = medicineList.Select(x =>
            {
                return new DoctorsOrderViewModel()
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
            }).ToList(); ;
            temp.AddRange(transformed);
            DrugItemsComboForSearch.AddRange(transformed);
            var MedicineCategoryItemsCombo = transformed.Select(m => (catId: m.CategoryID, catName: m.CategoryName)).Distinct().ToList();
            return MedicineCategoryItemsCombo;
        }
