        [Route("api/User")]
        public class UserApiController : MyControllerBase
        {
            [HttpGet("{id}/status")]
            [ProducesResponseType(200, Type = typeof(DeviceStatus))]
            [ProducesResponseType(404)]
            public async Task<IActionResult> GetStatus(Guid id)
            {
                // gets the device status
                return Ok(new DeviceStatus { DeviceId = id });
            }
            [HttpPost("{id}/status/rawdata")]
            [ProducesResponseType(201, Type = typeof(DeviceStatus))]
            [ProducesResponseType(404)]
            public async Task<IActionResult> CreateStatusFromRawData(Guid id, [FromBody]byte[] rawdata)
            {
                // some parsing logic
                return CreatedAtAction(nameof(GetStatus), new { id });
            }
            [HttpPut("{id}/status/rawdata")]
            [ProducesResponseType(200, Type = typeof(DeviceStatus))]
            [ProducesResponseType(404)]
            public async Task<IActionResult> UpdateStatusFromRawData(Guid id, [FromBody]byte[] rawdata)
            {
                // some parsing logic
                return UpdatedAtAction(nameof(GetStatus), new { id });
            }
        }
