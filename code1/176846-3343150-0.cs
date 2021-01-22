    [HttpPost]
    public ActionResult Index(HttpPostedFileBase file)
    {
        if (file != null && file.ContentLength > 0 && file.ContentType == "text/xml")
        {
            var document = new XmlDocument();
            document.Load(file.InputStream);
            // TODO: work with the document here
        }
        return View();
    }
