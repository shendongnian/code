    [HttpPost]
    public void Register(SampleModel request)
    {
        if (request == null)
        {
            var response = Request.CreateErrorResponse(
                 HttpStatusCode.BadRequest, 
                 "Missing or invalid SampleModel");
            throw new HttpResponseException(response);
        }
        ...
    }
