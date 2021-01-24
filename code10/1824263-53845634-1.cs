    [HttpPost]
    public ActionResult Delete(int id)
    {
        db.Delete<Logs>(id);
        // other stuff
        return PartialView("PartialViewName");
    }
