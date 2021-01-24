    [HttpPost("search")]
    public IActionResult test([FromBody]TestModel model) {
        if(ModelState.IsValid) {
            var country = model.country;
            var amount = model.amount;
            System.Console.WriteLine(country);
            System.Console.WriteLine(amount);
            return Ok( new { success = true });
        }
        return BadRequest(ModelState);
    }
