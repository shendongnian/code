    public class Worker: IWorker
    {
        private readonly IHttpClientManager _httpClient;
        private readonly ITokenService _tokenService;
        private readonly SemaphoreSlim _semaphore;
        public Worker(IHttpClientManager httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            // we want to limit the number of items here
            _semaphore = new SemaphoreSlim(10);
        }
        public async Task<JObject> ProcessRequestAsync(string request, string route)
        {
            try
            {
                var accessToken = await _tokenService.GetTokenAsync(
                    _timeSeriesConfiguration.TenantId,
                    _timeSeriesConfiguration.ClientId,
                    _timeSeriesConfiguration.ClientSecret);
                var cancellationToken = new CancellationTokenSource();
                cancellationToken.CancelAfter(30000);
                await _semaphore.WaitAsync(cancellationToken.Token);
                var httpResponseMessage = await _httpClient.SendAsync(new HttpClientRequest
                {
                    Method = HttpMethod.Post,
                    Uri = $"https://someuri/someroute",
                    Token = accessToken,
                    Content = request
                });
                var response = await httpResponseMessage.Content.ReadAsStringAsync();
                
                return response;
            }
            catch (Exception ex)
            {
                // do some logging
                throw;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
