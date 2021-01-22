    [ActionName("Get")]  
    public ActionResult Get()
    {
        return PartialView(/*return all things*/);
    }
    
    [ActionName("GetById")]  
    public ActionResult Get(int? id)
    {
       //code
    }
