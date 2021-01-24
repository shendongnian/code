    Public ActionResult Index()
    {  
     viewbag.Childone=Childone();
     viewbag.Childtwo=Childtwo()
     return View(parentModel);
    }
    
    [HttpPost]
    public ActionResult Index(ParentModel parentModel,Childone child_one ,Childtwo child_two)
     {
      //do something with models passed....
     }
