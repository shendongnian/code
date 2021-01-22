    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(int id, Department dept)
    {
        Department tmp = new Department()
        {
            Id = dept.Id
        };
        try
        {
            db.Departments.Attach(dept, tmp);
            db.Save();
        }
    }
