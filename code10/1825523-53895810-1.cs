    public class NamedClientModel : PageModel
    {
    private readonly IHttpClientFactory _clientFactory;
    public IEnumerable<GitHubPullRequest> PullRequests { get; private set; }
    public bool GetPullRequestsError { get; private set; }
    public bool HasPullRequests => PullRequests.Any();
    public NamedClientModel(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task OnGet()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, 
            "repos/aspnet/docs/pulls");
        var client = _clientFactory.CreateClient("github");
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            PullRequests = await response.Content
                .ReadAsAsync<IEnumerable<GitHubPullRequest>>();
        }
        else
            {
            GetPullRequestsError = true;
            PullRequests = Array.Empty<GitHubPullRequest>();
            }
        }
    }
