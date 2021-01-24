    private IActionResult EditPersonCore(PersonDto person)
    {
       //Do something with person model
       return Ok();
    }
    [HttpPost("EditPersonForm"]
    public IActionResult EditPersonForm(PersonDto person) => EditPersonCore(person);
    [HttpPost("EditPersonJson"]
    public IActionResult EditPersonJson([FromBody]PersonDto person) => EditPersonCore(person);
