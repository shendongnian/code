    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Employee employee)
    {
        Debug.Print(employee.Name);
        if (ModelState.IsValid)
        {
            //db.Employees.Add(employee);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        return View(employee);
    }
