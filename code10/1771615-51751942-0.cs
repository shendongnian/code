    public ActionResult Index(string param)
    {
        SomeClass viewmodel;
        if (string.IsNullOrEmpty(param))
        {
           // get complete list
           viewmodel = GetCompleteList();
        }
        else
        {
           // get list based on param value
           viewmodel = GetListByParam(param);
        }
     
        return View(viewmodel);
    }
