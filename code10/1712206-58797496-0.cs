    public IHttpActionResult DeleteEmailTemplate(int id)
        {
            FormResponse formResponse = new FormResponse("SUCESS MESSAGE HERE");
    
            List<string> strings = new List<string>();
            strings.Add("this is a test");
            strings.Add("this is another test");
    
            return Json(new { MessageResult = formResponse, TestObject = strings });
        }
