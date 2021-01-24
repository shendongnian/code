    public class GameApiService : IGameApiService
        {
            private readonly HttpClient _httpClient;
            private readonly HttpContext _httpContext;
    
            public GameApiService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClient;
                _httpContext = httpContextAccessor.HttpContext;
    
                _httpClient.AddBearerToken(_httpContext); // Add current access token to the authorization header
            }
    
            public async Task<(HttpResponseMessage response, string content)> GetDepartments()
            {
                return await GetAsync(Constants.EndPoints.GameApi.Department); // "api/Department"
            }
    
            public async Task<(HttpResponseMessage response, string content)> GetDepartmenById(string id)
            {
                return await GetAsync($"{Constants.EndPoints.GameApi.Department}/{id}"); // "api/Department/id"
            }
    
            private async Task<(HttpResponseMessage response, string content)> GetAsync(string request)
            {
                string content = null;
                
                var expiresAt = await _httpContext.GetTokenAsync(Constants.Tokens.ExpiresAt);             // Get expires_at value
    
                if (string.IsNullOrWhiteSpace(expiresAt)                                                  // Should we renew access & refresh tokens?
                    || (DateTime.Parse(expiresAt).AddSeconds(-60)).ToUniversalTime() < DateTime.UtcNow)   // Make sure to use the exact UTC date formats for comparison 
                {
                    var accessToken = await _httpClient.RefreshTokensAsync(_httpContext);                 // Try to ge a new access token
    
                    if (!string.IsNullOrWhiteSpace(accessToken))                                          // If succeded set add the new access token to the authorization header
                        _httpClient.AddBearerToken(_httpContext);
                }
    
                var response = await _httpClient.GetAsync(request);
    
                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                }
                else if (response.StatusCode != HttpStatusCode.Unauthorized && response.StatusCode != HttpStatusCode.Forbidden)
                {
                    throw new Exception($"A problem happened while calling the API: {response.ReasonPhrase}");
                }
    
                return (response, content);
            }
    
        }
    
    public interface IGameApiService
    {
        Task<(HttpResponseMessage response, string content)> GetDepartments();
        Task<(HttpResponseMessage response, string content)> GetDepartmenById(string id);
    }
