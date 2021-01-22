    public class User
    {
      public Password Password { get; set; }
    }
    
    public class Password
    {
      private string value;
      private string salt;
    
      public Password(string value)
      {
        this.salt = "generated salt";
        this.value = value;
      }
    
      public string ToHashedString()
      {
        // Return the hashed password.
      }
    }
