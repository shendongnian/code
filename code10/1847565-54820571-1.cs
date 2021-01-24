        public enum Departments  // Enumerating a database key like this can be helpful if the database itself doesn't describe the numbers in a lookup table or something
        {
            IT = 1,
            Admin = 2
        };
        [HttpGet]
        public ActionResult Status()
        {
            var Inventory = context.Inventory.ToList(); // Get all records
            var ViewModel = new List<Models.ProductsInDepartments>();
            foreach (int ProductId in Inventory.Select(e => e.ProductId).Distinct().ToList())
            {
                ViewModel.Add(new Models.ProductsInDepartments()
                {
                    ProductId = ProductId,
                    ProductName = Inventory.First(e => e.ProductId == ProductId).ProductName,
                    AdminTotal = Inventory.Count(e => e.ProductId == ProductId && e.DepartmentId == (int)Department.Admin),
                    ITTotal = Inventory.Count(e => e.ProductId == ProductId && e.DepartmentId == (int)Department.IT),
                    Status = Inventory.First(e => e.ProductId == ProductId).Status // I'm not sure what you are trying to do with Status, so you might need to change this
                });
            }
            return View(ViewModel);
        }
