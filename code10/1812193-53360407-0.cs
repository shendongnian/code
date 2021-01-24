    public async Task<T> GetAsync<T>(string endpointUrl, CancellationToken cancellationToken = new CancellationToken())
        {
            var restRequest = new RestRequest()
            {
                Resource = endpointUrl,
                Method = Method.GET
            };
            restRequest.AddHeader("Authorization", $"bearer {this.tokenHandler.GetToken()}");
            IRestResponse response = await this.restClient.ExecuteTaskAsync(restRequest, cancellationToken);
            switch ((int)response.StatusCode)
            {
                case int sc when (sc >= 200 && sc < 300):
                {
                    var responseData = JsonConvert.DeserializeObject<T>(response.Content);
                    return responseData;
                }
                case 401:
                {
                    throw new ApiAuthorizationException();
                }
                default:
                {
                    throw new ApiException(response.StatusCode,endpointUrl, response.Content);
                }
            }
        }
