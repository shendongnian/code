    public class ***Some***Controller : ApiController
    {
        [HttpGet]
        [Route( "api/***entity***/{id:int:min(1)}" )]    <--- won't work without the constraint resolver
        public async Task<IHttpActionResult> ApiAction( int id )
        {
            //Accessible by using ?api-version=2.0 OR by omitting that since this is the default version
            return Ok();
        }
 
