    [ChildActionOnly]
    public ActionResult HelloWorld()
    {
        if (It_Is_Time_To_Call_HelloWorld_On_ClientSide)
        {
            return View();
        }
        return new EmptyResult();
    }
