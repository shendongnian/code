    public class RegistrationViewModel : BindableBase
    {
        ...
        private readonly IRegistrationService _registrationService;
        public RegistrationViewModel(IRegistrationService registrationService)
        {
            _registrationService = registrationService ?? throw new ArgumentNullException(nameof(registrationService));
            RegisterCommand = new DelegateCommand(Register);
        }
        private void Register()
        {
            _registrationService.Register(...);
        }
    }
