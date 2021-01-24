    [HttpGet]
    public ActionResult Homepage()
    {
        return View(new LogReg.Models.Login());
    }
