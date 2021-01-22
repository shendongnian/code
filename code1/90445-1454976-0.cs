    public class AccountPersonalDetails
    {
       public OtherInfo OtherInfo { get; private set; }
    }
    
    public class ProductChecker
    {
         public ProductChecker(AccountPersonalDetails) {}
    }
    
    // and here's the important piece
    public class EitherServiceOrRepository
    {
       public static AccountPersonalDetails GetAccountDetailsByNumber(int accountNumber)
       {
           // access db here
       }
       
       // you may also feel like a bit more convinience via helpers
       // this may be inside ProductCheckerService, though
       public static ProductChecker GetProductChecker(int accountNumber)
       {
          return new ProductChecker(GetAccountDetailsByNumber(accountNumber));
       }
    }
