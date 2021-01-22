    public class UserFriendlyException : Exception
    {
      public string UserErrorMessage { get; set; }
    
      public UserFriendlyException(string message, SqlException exc) : base(message, exc)
      {
         UserErrorMessage = MapTechnicalExecptionToUserMessage(exc);
      }
    }
