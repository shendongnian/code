    [HttpPatch]
    public ActionResult ChangePositioningPlan(ChangePositioningPlan changeCommand)
    {
        try
        {
            changePositioingPlan.Process(changeCommand);
            return Ok("true");
        }
        catch(Exception ex)
        {
            return new HttpStatusCodeResult(500, ex.Message);
        }
    }
