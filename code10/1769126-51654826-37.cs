    [HttpGet]
    public IHttpActionResult ApiName()
    {
        var myObject = new Item { Id = 1, Name = "Matthew", Salary = 25000, Department = null };
    
        return Json(myObject, new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        });
    }
