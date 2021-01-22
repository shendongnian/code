    [HttpGet]
    public ActionResult ThePage(int id = -1)
    {
        if(id == -1)
        {
            return RedirectToAction("Index");
        }
        
        //Or proceed as normal
    }
