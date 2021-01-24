    public class AddressService : IAddressService
    {
        private readonly IAddressRepository repo;
        public AddressService(IAddressRepository repo, IUserContext userContext)
        {
           this.repo = repo;
        } 
        public IReadOnlyList<IState> GetAllStates()
        {
            // other logic removed
        }
    }
