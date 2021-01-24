    public class ExcludeRoleRequirement : IAuthorizationRequirement
    {
      public string Role { get; private set; }
      public ExcludeRoleRequirement(string role)
      {
        Role = role;
      }
    }
