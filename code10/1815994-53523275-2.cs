    public class AccountApplicationService {
         private DbContext _dbContext;
         private AccountDomainService _domainService;
         // you can use Dependency Injection to provide the appropiate dbContext and domainService
         public AccountApplicationService(DbContext dbContext, AccountDomainService domainService) {
             _dbContext = dbContext;
             _domainService = domainService;
         }
         public Account OpenNewAccount(OpenNewAccountCommand command) {
             
             // validate user input ...
             Validate(command);
             // load bank account from the database
             var accountToWithdrawGift = _dbContext.Accounts.Single(a => a.Name == "Bank Ldt.");
             const decimal giftAmount = 400.00M;
             // call domain service to execute the business case
             var newAccount = _domainService.OpenNewAccount(command.Name, accountToWithdrawGift, giftAmount);
              
             // persist new Account in the Database
             _dbContext.Accounts.Add(newAccount);
             _dbContext.SaveChanges();
             return newAccount;
         }
    }
