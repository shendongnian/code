csharp
services.AddHttpClient();
**Note**: There are multiple usage patterns, this is the most basic one. Look into the docs for other patterns, which may suite your needs better.
Later, in the class, where from you'd like to make http requests, take a dependency on `IHttpClientFactory` and let DI instantiate it for you as necessary. Here is the sample from Microsoft Docs:
csharp
public class BasicUsageModel : PageModel
{
    private readonly IHttpClientFactory _clientFactory;
    public IEnumerable<GitHubBranch> Branches { get; private set; }
    public bool GetBranchesError { get; private set; }
    public BasicUsageModel(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task OnGet()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, 
            "https://api.github.com/repos/aspnet/docs/branches");
        request.Headers.Add("Accept", "application/vnd.github.v3+json");
        request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            Branches = await response.Content
                .ReadAsAsync<IEnumerable<GitHubBranch>>();
        }
        else
        {
            GetBranchesError = true;
            Branches = Array.Empty<GitHubBranch>();
        }                               
    }
}
