    public class DataProvider : IDataProvider
    {
        private readonly IDataService _service;
        public DataProvider(IDataService _service)
        {
            _service = service;
        }
        public List<Appointments> GetAllAppointments()
        {
            return _service.GetAllAppointments();
        }
    }
    public interface IDataProvider
    {
        List<Appointments> GetAllAppointments();
    }
