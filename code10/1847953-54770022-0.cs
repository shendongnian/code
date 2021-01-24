    [HttpGet]
    public ActionResult ReglasDispositivos()
    {
        ClienteReglasDispositivos model = new ClienteReglasDispositivos();
        return View(model);
    }
    
    [HttpPost]
    public ActionResult ReglasDispositivos([FromForm] ClienteReglasDispositivos  model)
    {
        if(ModelState.IsValid(model)) {
         //do something
        }
        return View(model);
    }
