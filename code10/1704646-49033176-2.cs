     public class YourClass
     {
          public YourClass(Guid token)
          {
               // Validate token and throw exception if not valid
               Token = token;
          }
          public static Guid Token { get; set; }
     }
