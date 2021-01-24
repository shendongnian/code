    public class EmailActivaitonKey
    {
        private readonly IActivationService _activationService;
        public EmailActivaitonKey(IActivationService service)
        {
            this._activationService = service;
        }
        ....
    }
