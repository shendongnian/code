    [HttpPatch]
    [CatchException]
    public IHttpActionResult ChangePositioningPlan(ChangePositioningPlan changeCommand)
    {
        return Ok(changePositioingPlan.Process(changeCommand));
    }
      
