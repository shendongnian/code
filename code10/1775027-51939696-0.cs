    protected async Task<HttpOperationResponse<Botdata>> UpsertData(string channelId, string userId, string conversationId, BotStoreType storeType, BotData data)
    {
        var _result = new HttpOperationResponse<Botdata>();
        _result.Request = new HttpRequestMessage();
        try
        {
            var address = AddressFrom(channelId, userId, conversationId);
            await memoryDataStore.SaveAsync(address, storeType, data, CancellationToken.None);
        }
        catch (HttpException e)
        {
            _result.Body = data;
            _result.Response = new HttpResponseMessage { StatusCode = HttpStatusCode.PreconditionFailed };
            return _result;
        }
        catch (Exception)
        {
            _result.Response = new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError };
            return _result;
        }
        _result.Body = data;
        _result.Response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        return _result;
    }
