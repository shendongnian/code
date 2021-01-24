    Task.Run(async () => 
    {
        try
        {
            logger.VerboseRequest(tokenParameters.Endpoint, payloadJson, options);
            serializedResponse = await httpHandler.PostAsync<string>
                                     (tokenParameters.Endpoint, payloadJson, options, cts.Token);
        }
        catch (TaskCanceledException)
        {
            throw new TokenTimeoutException();
        }
        catch (Exception ex)
        {
            logger.Error(String.Format("Error when posting to Endpoint: {0}",ex.Message));
            throw;
        }
    }).ConfigureAwait(false);
