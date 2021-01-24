    public IActionResult AddOrUpdate([FromQuery]string recurringJobId = "",[FromQuery]string methodName = "", [FromQuery] bool remove = false, [FromQuery] string cronExpression = "*/1 * * * *", [FromBody] Parameters parameters = null)
    {
      RecurringJob.AddOrUpdate<JobsService>(
               recurringJobId, 
               js => js.InvokeMethod(methodName, parameters), 
               () => cronExpression
               );
    }
