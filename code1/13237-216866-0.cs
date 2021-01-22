    public class CustomerInfo
    {
      public Customer Customer { get; set; }
      public bool IsEditable { get; set; }  // e.g. based on current user/role
      public bool NeedFullAddress { get; set; }  // e.g. based on requested action 
      public bool IsEligibleForSomething { get; set; }  // e.g. based on business rule
    } 
