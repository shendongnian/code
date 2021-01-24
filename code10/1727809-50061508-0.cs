    [Authorize]
    [ODataRoutePrefix("Customer")]
    public class CustomerController : ODataController
    {
        [...]
        [EnableQuery]
        public IHttpActionResult Get()
        {
            if (!string.IsNullOrWhiteSpace(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.FirstOrDefault(c => c.Type == "IsAdmin").Value))
            {
                return Ok(context.Customers);
            }
            return Unauthorized();
        }
        
        [...]
    }
