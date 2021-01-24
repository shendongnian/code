    public class HttpClientFactory_Polly_Policy_Test
    {
        [Fact]
        public async Task Given_a_retry_policy_configured_on_a_named_client_When_call_via_the_named_client_Then_the_policy_is_used()
        {
            // Given / Arrange 
            IServiceCollection services = new ServiceCollection();
            bool retryCalled = false;
            HttpStatusCode codeHandledByPolicy = HttpStatusCode.InternalServerError;
            const string TestClient = "TestClient";
            services.AddHttpClient(TestClient)
                .AddPolicyHandler(HttpPolicyExtensions.HandleTransientHttpError()
                    .RetryAsync(3, onRetry: (_, __) => retryCalled = true))
                .AddHttpMessageHandler(() => new StubDelegatingHandler(codeHandledByPolicy));
            HttpClient configuredClient =
                services
                    .BuildServiceProvider()
                    .GetRequiredService<IHttpClientFactory>()
                    .CreateClient(TestClient);
            // When / Act
            var result = await configuredClient.GetAsync("https://www.doesnotmatterwhatthisis.com/");
            // Then / Assert
            Assert.Equal(codeHandledByPolicy, result.StatusCode);
            Assert.True(retryCalled);
        }
    }
    public class StubDelegatingHandler : DelegatingHandler
    {
        private readonly HttpStatusCode stubHttpStatusCode;
        public StubDelegatingHandler(HttpStatusCode stubHttpStatusCode) => this.stubHttpStatusCode = stubHttpStatusCode;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) => Task.FromResult(new HttpResponseMessage(stubHttpStatusCode));
    }
