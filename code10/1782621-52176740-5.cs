    public static class MainClass
    {
        public class Medicine
        {
            public string PKID { get; set; }
            public string Name { get; set; }
            public string UnitName { get; set; }
            public string CategoryID { get; set; }
            public string CategoryName { get; set; }
            public string DosageFormID { get; set; }
            public string InventoryTypeID { get; set; }
        }
        public class DoctorsOrderViewModel
        {
            public string DrugID { get; set; }
            public string Name { get; set; }
            public string DrugName { get; set; }
            public string UnitName { get; set; }
            public string CategoryID { get; set; }
            public string CategoryName { get; set; }
            public string DosageFormID { get; set; }
            public string InventoryTypeID { get; set; }
        }
        class Category
        {
            public string CategoryID { get; set; }
        }
        public static void Main()
        {
            
            var medicines = new List<Medicine>();
            medicines.AddRange(Enumerable.Range(0, 13000).Select(i => new Medicine()
            {
                PKID = "PKID" + i,
                Name = "Name" + i,
                UnitName = "UnitName" + i,
                CategoryID = "CategoryID" + i%1000,
                CategoryName = "CategoryName for CategoryID" + i%1000,
                DosageFormID = "DosageFormID" + i,
                InventoryTypeID = "InventoryTypeID" + i,
            }));
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<DoctorsOrderViewModel> comboData = null;
            for (int i = 0; i < 10; i++)
            {
                comboData = OpWay(medicines);
            }
            var elapsed = sw.Elapsed;
            Console.WriteLine($"10x OPWay for {medicines.Count} medicines and {comboData.Count} categories: {elapsed}");
            sw.Restart();
            List<(string catId, string catName)> comboData2 = null;
            for (int i = 0; i < 10; i++)
            {
                comboData2 = MyWay(medicines);
            }
            elapsed = sw.Elapsed;
            Console.WriteLine($"10x MyWay for {medicines.Count} medicines and {comboData2.Count} categories: {elapsed}");
        }
        public static List<DoctorsOrderViewModel> OpWay(List<Medicine> medicineList)
        {
            List<DoctorsOrderViewModel> MedicineCategoryItemsCombo = new List<DoctorsOrderViewModel>();
            var temp = new List<DoctorsOrderViewModel>();
            var DrugItemsComboForSearch = new List<DoctorsOrderViewModel>();
            medicineList.ForEach(x =>
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
                DrugItemsComboForSearch.Add(vm);
                DoctorsOrderViewModel vm2 = new DoctorsOrderViewModel() { CategoryID = x.CategoryID, CategoryName = x.CategoryName, };
                if (!MedicineCategoryItemsCombo.Select(y => y.CategoryID).Contains(x.CategoryID))
                {
                    MedicineCategoryItemsCombo.Add(vm2);
                }
            });
            return MedicineCategoryItemsCombo;
        }
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
    }
