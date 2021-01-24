    class Consumer
    {
      public void Test()
      {
        var apiResponse = Policy<IApiResponse>
          .HandleResult(resp => !string.IsNullOrWhiteSpace(resp.ErrorCode))
          // Setup Policy
          .ExecuteAsync(() => otherClassInstance.MakeApiCall());
      }
    }
    class OtherClass
    {
      HttpClient httpClient = ...;
      public async Task<IApiResponse> MakeApiCall()
      {
        var response = Policy<HttpResponseMessage>
          .HandleResult(message => !message.IsSuccessStatusCode)
          // Setup Policy
          .ExecuteAsync(() => httpClient.GetAsync(url));
        var content = await response.ReadAsStringAsync();
        return new ApiResponse(content);
      }
    }
