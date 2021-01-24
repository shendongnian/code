    [Route("cloudapi")]
    public class LegacyController : ControllerBase
    {
        [HttpPost]
        [EnableRewindResourceFilter]
        [Route("regionslist")]
        public dynamic RegionsList([FromBody] byte[] bytes )
        {
            return new JsonResult(bytes);
        }
    }
