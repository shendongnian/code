    [RoutePrefix("api/Users")]
    public class UsersController : BaseController<UserObject>
    {
        public override IHttpActionResult Post([FromBody]JObject newFields)
        {
            // Overridden post logic
            return Ok();
        }
    }
