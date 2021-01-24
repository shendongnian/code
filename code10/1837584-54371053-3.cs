    public async Task<ActionResult<Thing>> Get() {
        Thing thing = await Context.Things;
        if (thing == null)
            return NotFound();
        else
            return thing;
    }
