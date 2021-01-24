    public class HomeController : Controller
     {
         private readonly IPlatformRepository _platformRepository;
         private readonly IDeviceRepository _deviceRepository;
    
        
         public HomeController(IPlatformRepository platformRepository, IDeviceRepository deviceRepository)
         {
             this._platformRepository = platformRepository;
             this._deviceRepository = deviceRepository;
    
         }
