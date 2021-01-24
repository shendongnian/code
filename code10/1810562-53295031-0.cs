    public LogInvalidDataRequstFilterAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(ActinExecutingContext filterContext)
      {
        if (!filterContext.Controller.ViewData.ModelState.IsValid)
        {
          // Data isn't valid so now what?
        }
      }
    }
    [LogInvalidDataRequestFilter]
    [HttpPost("[action]")]
    public ResultSet AddApplication([FromBody] Application model)
    {
     // Code Here
    }
