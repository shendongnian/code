    public ActionResult Process()
    {
        return View(new Data { Id = -1 });
    }
    
    [HttpPost]
    public ActionResult Process(Data data)
    {
        if (!this.ModelState.IsValid)
        {
            return View(data);
        }
        new MyService().ProcessData(data);
        return RedirectToAction("Process");
    }
