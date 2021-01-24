    public async Task<ISentimentEngineResult> AnalyseSentimentAsync(ISentimentRequest request)
    {
        try
        {
            MultiLanguageBatchInput sentimentList = SentimentRequestToMicrosoftBatchInput(request, Properties.Settings.Default.DefaultLanguage);
            SentimentBatchResult sentiment = await _client.SentimentAsync(sentimentList);
            KeyPhraseBatchResult keyPhrases = await _client.KeyPhrasesAsync(sentimentList);
            return MicrosoftBatchResultsToSentimentEngineResult(sentiment, keyPhrases);
        }
        catch (Exception ex)
        {
            _logger.LogMessage(ex,$"{EngineName} threw an unknown exception: ", LoggingLevel.Error);
            throw;
        }
    }
    
    private async Task<ISentimentResponse> ProcessRequestAsync(ISentimentRequest request, SentimentEngineServices selectedEngines)
    {
        SentimentResponse response = new SentimentResponse();
        List<Task<ISentimentEngineResult>> taskList = new List<Task<ISentimentEngineResult>>();
        foreach (SentimentEngineServices engineService in (SentimentEngineServices[])Enum.GetValues(typeof(SentimentEngineServices)))
        {
            if (((int)engineService & (int)selectedEngines) > 0)
            {
                ISentimentEngine engine = _engineFactory.GetSentimentEngine(engineService, null);
                Task<ISentimentEngineResult> task = engine.AnalyseSentimentASync(request);
                taskList.Add(task);
            }
        }
        if (taskList.Count > 0)
        {
            ISentimentEngineResult[] results = await Task.WhenAll(taskList);
            foreach (result in results)
                response.Add(results);
        }
        return response;
    }
