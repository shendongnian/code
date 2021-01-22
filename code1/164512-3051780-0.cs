    public interface IServiceFacade {
        string Assignments();
    }
    public class ServiceFacade : IServiceFacade {
        private readonly Service _service;
        public ServiceFacade(Service service) {
            _service = service;
        }
        public string Assignments() {
            return _service.Assignments();
        }
    }
