    public class TimeAllocationController : BaseApiController
    {
        [Route("api/timeallocation")]
        [HttpPost]
        public async Task<ActivityValidationResult> Post([FromBody] string id)
        {
            //logic here...
        }
