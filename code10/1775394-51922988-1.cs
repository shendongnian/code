    [Route("api/Permiso")]
    [ApiController]
    public class PermisoController : ControllerBase {
        private readonly IMapper _mapper;
        private readonly IBusinessLogicHelper _blh;
        public PermisoController(BusinessLogicHelper blh, IMapper mapper) {
            _blh = blh;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get() {
            try {
                // Get raw data from entities
                var resultsRaw = _blh.GetDataRaw();
                if (resultsRaw == null) {
                    return NotFound();
                }
                // Mapping data from entity to DTO
                var resultsDTO = _mapper.Map<ReturnDataDTO>(resultsRaw);
                return Ok(resultsDTO);
            } catch (Exception ex) {
                // Custom ObjectResult for InternalServerError
                return new InternalServerErrorObjectResult(ex.Message);
            }
        }
    }    
