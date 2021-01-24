    public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            string xmlData="<xml ?>.....";
            return Content(xmlData, "text/xml");
       }
