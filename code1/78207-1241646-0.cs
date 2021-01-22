     public enum AccountStatusEnum
     {
          Active = 1,
          Trial = 2,
          Canceled = 3
     }
     public class AccountStatus
     {
          private AccountStatusEnum status
          //
          // Constructor
          public AccountStatus(AccountStatusEnum status)
          {
              this.Status = status;
          }
 
          public int Id { get; set; }
          public string Description { get; set; }
          //
          // Business logic for IsActive
          public bool IsActive 
          { 
               get { return status == 1; }
          }
          public bool CanReactivate { get; set; }
     }
