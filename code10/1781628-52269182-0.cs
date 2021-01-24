    [ValidateInput(false)]
    public ActionResult IPNHandler()
    {
        byte[] param = Request.BinaryRead(Request.ContentLength);
        string strRequest = Encoding.ASCII.GetString(param);
    	
    	//TODO: print string request 
    	
    	//nothing should be rendered to visitor
        return Content("");	
    } 
