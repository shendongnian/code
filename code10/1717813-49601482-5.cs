    public ActionResult Edit(int id)
    {
        EmployeeDB edb = new EmployeeDB();
        var depart = edb.GetDepartment();
        ViewBag.Departments = new SelectList(depart, "DepartmentId", 
      "DepartmentName");
    
    
        return PartialView(edb.GetEmployees().Find(cmodel => cmodel.Id == id));
    }
