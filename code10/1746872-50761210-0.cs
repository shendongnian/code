    public class AltAuthSource: DefaultExternalAuthenticationSource<Tenant, User>, ITransientDependency
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly UserManager _userManager;
        public override string Name => "AltSource";
        public AltAuthSource(IRepository<User, long> userRepository, UserManager userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public override Task<bool> TryAuthenticateAsync(string userNameOrEmailAddress, string plainPassword, Tenant tenant)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.UserName.Equals(userNameOrEmailAddress, StringComparison.InvariantCultureIgnoreCase) || x.EmailAddress.Equals(userNameOrEmailAddress, StringComparison.InvariantCultureIgnoreCase));
            if (user == null || !string.IsNullOrWhiteSpace(user.Password))
            {
                return Task.FromResult(false);
            }
            else
            {
                var passwordOk = BCrypt.Net.BCrypt.Verify(plainPassword, user.PasswordOrig);
                if (passwordOk)
                {
                    _userManager.ResetAccessFailedCountAsync(user);
                    var newHash = _userManager.PasswordHasher.HashPassword(user, plainPassword);
                    user.Password = newHash;
                    return Task.FromResult(true);
                }
                else
                {
                    _userManager.AccessFailedAsync(user);
                    return Task.FromResult(false);
                }
            }
        }
    }
