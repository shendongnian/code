    public class GearComponentsController : ControllerBase
    {
    private readonly IGearComponentRepository _gearComponentRepository;
    
    public GearComponentsController(IGearComponentRepository 
    _gearComponentRepository)
    {
      _gearComponentRepository = gearComponentRepository;
    }
     
    [HttpPost]
    public IActionResult Create(GearComponent data)
    {
        _dataRepository.Create(data);
        return Ok();
    }
    }
