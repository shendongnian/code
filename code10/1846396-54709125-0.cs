    [HttpGet]
    [Route("{vehicleId}")]
    public InfoDto GetInfo(int vehicleId, [FromUri] string lang)
    {
       return ...;
    }
