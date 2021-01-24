    [HttpPost]
    public JsonResult GetSecondData(int firstId)
    {
         var result = ...; //populate result   
         return new JsonResult { Data = result };
    }
