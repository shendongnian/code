    public ActionResult Edit([Bind(Include = "StudentId,StudentName,StudentContactNo,RegistrationDate,Address,DepartmentId,RegistrationNumber")] StudentForUpdate student)
    {
        if (ModelState.IsValid)
        {
            db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
        return View(student);
    }
