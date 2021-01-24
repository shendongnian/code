    public IActionResult ProcessForm([FromBody]Dictionary<string,string> contactFormRequest)
    {
        var message = "test";
        var result = true;
        //This will create an anonymous type! (you can see its named as "a'")
        var resultData = new { Message = message, Result = result }; 
        return Json(resultData);
    }
