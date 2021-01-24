    [HttpGet]
    public ActionResult ReglasDispositivos()
    {
        ClienteReglasDispositivos model = new ClienteReglasDispositivos();
        return View(model);
    }
    
    [HttpPost]
    public ActionResult ReglasDispositivosPost([FromForm] ClienteReglasDispositivos  model)
    {
        return View("ReglasDispositivos", model);
    }
