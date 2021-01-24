    [HttpPost]
    public ActionResult Delete(int id)
    {
        db.Delete<Logs>(id);
        // other stuff
        string url = this.Url.Action("Index", "Log", new { id = id });
        return Json(url);
    }
