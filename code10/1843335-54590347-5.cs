    [HttpPatch]
    public ActionResult ChangePositioningPlan(ChangePositioningPlan changeCommand)
    {
        try
        {
            changePositioingPlan.Process(changeCommand);
            return new HttpStatusCodeResult(200, "true or something");
        }
        catch(Exception ex)
        {
            return new HttpStatusCodeResult(500, ex.Message);
        }
    }
