    public class SomeService : ISomeService
    {
      private readonly IdentityServerTools _identityServerTools;
      public SomeService(IdentityServerTools identityServerTools) 
      {
        _identityServerTools = identityServerTools;
      }
      private async Task<string> CreateTokenAsync()
      {
        // Get client for JWT
        var idpClient = _dbContext.Clients.FirstOrDefault(c => c.ClientId == SomeClientId);
        // Get scopes to set in JWT
        var scopes = idpClient.AllowedScopes.Select(s => s.Scope).ToArray();
        // Use in-built Identity Server tools to issue JWT
        var token = await _identityServerTools.IssueClientJwtAsync(idpClient.ClientId, idpClient.AccessTokenLifetime, scopes, new[] { "Some Api Name"})
      }
    }
