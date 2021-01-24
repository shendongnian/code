    [HttpPost]
    public ActionResult Edit(Student smodel)
    {
        try
        {
            StudentDBHandle sdb = new StudentDBHandle();
            sdb.UpdateDetails(smodel);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
