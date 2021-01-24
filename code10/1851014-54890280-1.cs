    public class DependsOnService
    {
        private readonly IService _service;
        public DependsOnService(IService service)
        {
            _service = service;
        }
    }
