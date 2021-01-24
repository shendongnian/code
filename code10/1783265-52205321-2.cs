    [HttpPost]
    public HttpResponseMessage MyPost([FromBody]List<clsStartTimeUpdate> StartTimeDetails)
    {
        return base.BuildSuccessResult(HttpStatusCode.OK, StartTimeDetails);
    }
