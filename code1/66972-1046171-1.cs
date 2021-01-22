    public ActionResult List(string format)
    {
        ...
        if(String.Compare("xml", format, true) == 0)
        {
            return View("ListInXml");
        }
        return View("List");
    }
