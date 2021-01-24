    [HttpPost]
    public ActionResult SaveResponse()
    {
        string json;
        using (var reader = new StreamReader(HttpContext.Request.InputStream))
        {
            json = reader.ReadToEnd();
        }
        return View("CallbackView");
    }
