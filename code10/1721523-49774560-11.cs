    public async Task<string> ProcessResponse(HttpResponseMessage pResponse)
    {
        string _responseStr = "";
        if (pResponse != null)
        {
            if (pResponse.IsSuccessStatusCode)
                _responseStr = await pResponse.Content.ReadAsStringAsync();
            else
            {
                _responseStr = await pResponse.Content.ReadAsStringAsync();
                var _error = JsonConvert.DeserializeObject<RestApiExceptionContainer>(_responseStr);
                throw new RestApiException(_error);
            }
        }
        return _responseStr;
    }
