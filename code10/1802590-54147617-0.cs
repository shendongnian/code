    [HttpPost]
    public ActionResult ReceiveName()
    {
        System.IO.Stream request = Request.InputStream;
        request.Seek(0, SeekOrigin.Begin);
        string bodyData = new StreamReader(request).ReadToEnd();
        var data = JsonConvert.DeserializeObject<SomeType>(bodyData);
	
	    //do something
    	return Json(new { success = true});
    }
