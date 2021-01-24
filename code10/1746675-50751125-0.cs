    public sealed class AvayaService
    {
        private readonly IRepository _repository;
        public AvayaService(IRepository repository)
        {
            if(repository == null)
                throw new ArgumentNullException();
            _repository = repository;
        }
        
        public static Response GetResponse(Request request)
        {
            // use _repository
        }
    }
