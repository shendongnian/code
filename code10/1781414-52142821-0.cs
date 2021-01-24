    [Route("api/[controller]")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        [HttpPost]
        public DummyDto PostTest([FromBody] DummyDto dto)
        {
            return dto;
        }
    }
