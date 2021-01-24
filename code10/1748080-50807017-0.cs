     public ActionResult Edit(int? id)
            {
                MYDb db = new MYDb();
                var user = db.Employees.Where(c => c.Employee_Id == Emodel.Employee_Id).FirstOrDefault();
                if (user != null)
                {
                    var vm = new EDViewModel { Employee_id = user.Employee_id, departmentName = user.departmentName };
                    if (user.department != null)
                    {
                        user.Departmet_id = vm.Departments.Departmet_id;
                        user.DepartmentName = vm.Departments.DepartmentName;
                        user.Employee_id = vm.employee_id;
                        user.employeeName = vm.employeeName;
                    }
                    return View(user);
                }
                return Content("Invalid Id");
            }
     [HttpPost]
            public ActionResult Edit(EDViewModel Emodel)
            {
                var user = db.Employees.Where(c => c.Employee_Id == Emodel.Employee_Id).FirstOrDefault();
                user.EmployeeId = Emodel.EmployeeId;
                user.EmployeeName= Emodel.EmployeeName;
              user.DepartmentName= Emodel.Departmt.DepartmentName;
             // Just remove this line
              //  db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Home");
            }
