    public IRestResponse<T> Put<T, W, V>(string ResourceUri, W MethodParameter) where V : Exception
                                                                                where T : new() {
        //  Handle to any logging context established by caller; null logger if none was configured
        ILoggingContext currentContext = ContextStack<IExecutionContext>.CurrentContext as ILoggingContext ?? new NullLoggingContext();
        currentContext.ThreadTraceInformation("Building the request...");
        RestRequest request = new RestRequest(ResourceUri, Method.PUT) {
            RequestFormat = DataFormat.Json,
            OnBeforeDeserialization = serializedResponse => { serializedResponse.ContentType = "application/json"; }
        };
        request.AddBody(MethodParameter);
        currentContext.ThreadTraceInformation($"Executing request: {request} ");
        IRestResponse<T> response = _client.Execute<T>(request);
        #region -  Handle the Response  -
        if (response == null)            {
            throw new OurBaseException("The response from the REST service is null");
        }
        //  If you're not following the contract, you'll get a serialization exception
        //  You can optionally work with the json directly, or use dynamic 
        if (!response.IsSuccessful) {                
            V exceptionData = JsonConvert.DeserializeObject<V>(response.Content);
            throw exceptionData.ThreadTraceError();
        }
        //  Timed out, aborted, etc.
        if (response.ResponseStatus != ResponseStatus.Completed) {
            throw new OurBaseException($"Request failed to complete:  Status '{response.ResponseStatus}'").ThreadTraceError();
        }
        #endregion
        
        return response;
    }
