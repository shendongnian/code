    [HttpPost]
    public ActionResult AddEmployee(EmployeeModel model)
    {
       var employee = EmployeeService.Value.Add(model);
       return RedirectToAction("EmployeeList", new { employeeId = employee.Id }); 
    }
    [HttpPost]
    public async ActionResult SetupEmployeeArea(int employeeId)
    {
       await SetupEmployeeArea(employeeId);
       //or better use some background worker
      
       return Json("some result");
    }
