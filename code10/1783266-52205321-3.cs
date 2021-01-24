    [HttpGet]
    public HttpResponseMessage MyGet(string StartTimeDetails)
    {
        List<clsStartTimeUpdate> clsStartTimeUpdates = JsonConvert.DeserializeObject<List<clsStartTimeUpdate>>(StartTimeDetails);
        return base.BuildSuccessResult(HttpStatusCode.OK, StartTimeDetails);
    }
