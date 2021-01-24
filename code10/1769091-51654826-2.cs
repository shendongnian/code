    public HttpResponseMessage ApiName()
    {
        var myObject = ObjectToPassAsResponse();
    
        return Content(Json(myObject, new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        }));
    }
