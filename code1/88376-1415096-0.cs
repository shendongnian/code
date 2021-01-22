    public class UserFriendlyException : Exception
    {
      public string UserErrorMessage { get; set; }
    
      public UserFriendlyException(SqlException exc) : base(exc)
      {
         UserErrorMessage = MapTechnicalExecptionToUserMessage(exc);
      }
    }
