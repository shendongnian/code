    public ActionResult<Thing> Get() {
        Thing thing = Context.Things;
        if (thing == null)
            return NotFound();
        else
            return thing;
    }
