    [Authorize]
    [Route("api/camps/{moniker}/speakers")]
    [ValidateModel]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class SpeakersController : BaseController
      [HttpGet]
      [MapToApiVersion("1.0")]
      [AllowAnonymous]
      public virtual IActionResult Get(string moniker, bool includeTalks = false)
    [Route("api/camps/{moniker}/speakers")]
    public class Speakers2Controller : SpeakersController
    
      public override IActionResult Get(string moniker, bool includeTalks = false)
      {  return NotFound(); }
      [ApiVersion("2.0")]
      public override IActionResult GetWithCount(string moniker, bool includeTalks = false)
