    [HttpGet("cars")]
    [Produces(typeof(List<Car>))]
    public async Task<IActionResult> GetCars([FromQuery] CarParams parameters) {
        //...
    
        return Ok(data);
    }
