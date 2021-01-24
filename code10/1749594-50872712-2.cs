    [HttpGet([controller]/[action]/{id})]
    public ActionResult BookClass(int id)
    {
        //get the gym based on the id
        return RedirectToAction("Index");
    }
