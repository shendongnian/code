    [Consumes("application/json")]
    [Produces("application/json")]
    public IActionResult Submit([FromBody]ViewModel model)
    {
      ModelState.IsValid; //use to inspect. You will also see any violations
      ....
    }
