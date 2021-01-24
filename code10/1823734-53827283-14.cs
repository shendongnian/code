        [Route("cloudapi")]
        public class LegacyController : ControllerBase
        {
            [EnableRewindResourceFilter]
            [HttpPost]
            [Route("regionslist")]
            public dynamic RegionsList([ModelBinder(typeof(BinaryBytesModelBinder))] Person person )
            {
                // now we gets the person here
            }
        }
