    public class HomeController:Controller
    {
       
        private readonly Service1 _service1;   
        public HomeController(Func<int, IContractService> serviceProvider)
        {
            _service1 = serviceProvider(1);            
        }
    }
