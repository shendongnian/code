    [HttpGet("Nominal/{powerFront}/{powerBack}")]
    public ActionResult<double> NominalPower(PowerModel powerModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        powerModel.Result = Power.NominalPower(powerModel.PowerFront, powerModel.PowerBack);
        return powerModel.Result;
    }
