    public class AccountController : ApiController  {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService) {
            this.accountService = accountService;
        }
    
        [HttpPost, ActionName("updateProfile")]
        public IHttpActionResult updateProfile([FromBody]RequestDataModel request) {
            var response = accountService.UpdateProfile(request.UserId, request.Salary);
            return Ok(response);
        }
    }
    public class AccountService : IAccountService {
        private readonly IAccountRepository accountRepository;
        public AccountService(IAccountRepository accountRepository) {
            this.accountRepository = accountRepository;
        }
    
        public int UpdateProfile(int userId, decimal salary) {
            return accountRepository.UpdateProfile(userId, salary);
        }
    }
