    public class RequiresClaimIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting( ActionExecutingContext context )
        {
             var claim = GetClaim( int.Parse( context.RouteData["id"] ) );
             if (claim == null)
             {
                  context.Result = new ViewResult
                  {
                       ViewName = "ClaimNotFound",
                       ViewData = context.Controller.ViewData
                  };
             }
             else
             {
                  var property = context.Controller
                                        .GetType()
                                        .GetProperty( "Claim",
                                                       BindingFlags.Public
                                                       | BindingFlags.NonPublic
                                                       | BindingFlags.Instance);
                  if (property != null)
                  {
                       property.SetValue(context.Controller,claim);
                  }
             }
        }
    }
    [RequiresClaimId]
    public ActionResult AnAction( int id )
    {
        this.Claim.Updated = DateTime.Now;
        ...
    }
