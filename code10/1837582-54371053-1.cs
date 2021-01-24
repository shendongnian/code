    public async Task<IActionResult> Get() {
        Thing thing = await Context.Things;
        if (thing == null)
            return NotFound();
        else
            return Ok(thing);
    }
