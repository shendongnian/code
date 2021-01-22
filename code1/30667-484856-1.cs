    public ActionResult List()
    {
        //some code here
    }
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult List(Building building)
    {
       ...
       var1 = building.FieldNumber1;
       var2 = building.FieldNumber2;
       ...
    }
