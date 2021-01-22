     public enum AccountStatusCode
     {
          Active = 1,
          Trial = 2,
          Canceled = 3
     }
     public class AccountStatus
     {
          private AccountStatusEnum status
          //
          // Constructor sets initial status.
          public AccountStatus(int status)
          {
              this.Status = (AccountStatusCode)status;
          }
 
          public int Id { get; set; }
          public string Description { get; set; }
          //
          // 
          public bool IsActive 
          { 
               get { return status == AccountStatusCode.Active; }
          }
          public bool CanReactivate { get; set; }
     }
