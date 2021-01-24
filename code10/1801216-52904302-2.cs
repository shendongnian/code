    [HttpGet]
    public ActionResult Index(int ID)
    {
       DEMO_MAST model=new DEMO_MAST();
      if(ID>0)
      {
         model=Find(ID);   
      } 
    return View(model);
    }
    
    [HttpPost]
    public ActionResult Index(DEMO_MAST model)
    {
      if(ModelState.IsValid)
      {
         int i = AddEdit(model); 
         if(i>0) 
         {
           ViewBag.Message="Record AddEdit Successfully";
         }
         else
         {
           ViewBag.Message="Error";
         }
      }
    return View(model);
    }
