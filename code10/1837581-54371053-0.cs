    public IActionResult Get() {
        Thing thing = Context.Things;
        if (thing == null)
            return NotFound();
        else
            return Ok(thing);
    }
