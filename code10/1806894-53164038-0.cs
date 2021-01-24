    [HttpGet]
    [Route("api/updateddetails")]
    public object GetUpdatedFleetStatusDetails([FromUrl]DateTime date)
    {
        var fmsData = this.fmsdb.Value.GetUpdatedFleetStatusDetails(date);
        return fmsData.Entries
            .Where(x => x != null)
            .Select(ConvertVehicleDetail);
    }
