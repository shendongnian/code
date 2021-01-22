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
          // Constructor sets initial status.
          public AccountStatus(int status)
          {
              this.Status = (AccountStatusEnum)status;
          }
 
          public int Id { get; set; }
          public string Description { get; set; }
          //
          // 
          public bool IsActive 
          { 
               get { return status == AccountStatusEnum.Active; }
          }
          public bool CanReactivate { get; set; }
     }
