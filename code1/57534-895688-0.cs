    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(Guid id, Department Model)
    {
        var dbDepartment = (from Department d in db.Department
                            where d.Id == id
                            select d).FirstOrDefault() as Department
        dbDepartment.Name = Model.Name;
        dbDepartment.Color = Model.Color;
        // etc, assigning values manually...
        try
        {
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            // oops...
        }
        return RedirectToAction("Index");
    }
