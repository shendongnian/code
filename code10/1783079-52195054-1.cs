    namespace nH.MasterData.API.Controllers {
        [Produces("application/json")]
        [Route("api/AType")]
        public class ATypeController : Controller {
            private readonly IProcessor _domain;
            private readonly ILogger _logger;
            private const string Version = "VERSION_1";
            private const string Model = "model";
            private const string Entity = "AType";
    
            public ATypeController(IProcessor domain, ILogger<ATypeController> logger) {
                _logger = logger;            
                _domain = domain;
            }
    
            [HttpGet]
            public IActionResult Get() {
                try {
                    return Ok(_domain.GetATypesMembers(Model, Version, Entity, MemberType.Leaf, null));
                } catch (Exception ex) {
                    _logger.LogError(ex.Message + " " + ex.StackTrace);
                    return BadRequest();
                }
            }
        }
    }
