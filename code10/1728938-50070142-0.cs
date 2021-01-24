    [HttpGet, Route("api/your/route/here")]
    public IHttpActionResult GetVehicle(int code)
    {
        Console.WriteLine("GetVehicle() code = " + code);
        var vehicle = vehicles.FirstOrDefault((v) => v.Code == code);
        if (vehicle == null)
        {
            return NotFound();
        }
        return Ok(vehicle);
    }
