    public class GitHubClient : IGitHubClient {
        private readonly HttpClient _client; //<< Handler will be attached to this instance
        public GitHubClient(HttpClient httpClient) {
            _client = httpClient;
        }
        public async Task<string> GetData() {
            return await _client.GetStringAsync("/");
        }
    }
