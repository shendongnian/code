     public ActionResult EmployeeData() {
            EmployeeViewModel model = new EmployeeViewModel();
            EmployeeDepartment ed = new EmployeeDepartment();
            model.Id = 1;
            model.Name = "Muhammmad Ashraf Faheem";
            model.Email = "it.ashraffaheem@gmail.com";
            ed.Id = 1;
            ed.DepartmentName = "Development";
            model.employeeDepartment = ed;
            return View(model);
        }
