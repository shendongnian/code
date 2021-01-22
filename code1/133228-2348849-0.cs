    public class CACSService
    {
        public CACService
        {
            // need to do this since WCF creates us
            KernelContainer.Inject( this );
        }
    
        [Inject]
        public IUserRepository Repository
        { set; get; }
    
        [Inject]
        public IBusinessRepository BusinessRepository
        { set; get; }
    }
