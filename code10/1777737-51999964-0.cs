    [HttpPost]
    public ActionResult Edit(int id, StudentModel smodel, int? currentPage){
        try {
            StudentDBHandle sdb = new StudentDBHandle();
            sdb.UpdateDetails(smodel);
            return RedirectToAction("Index", "MyController", new { page = currentPage } );
        }
        catch {
            return View();
        }
    }
