    [Produces("application/json", "application/xml")]
    public Task<IActionResult> GetByAddreses()
    {
        var result = _soapApi.GetResults();
    var response = ResponceMethod<List<Address>>.SuccessResponse(StatusCodes.Status200OK, "Success", result);
        return Ok(response);
    }
