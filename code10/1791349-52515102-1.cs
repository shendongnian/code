     public async Task<ISentimentEngineResult> AnalyseSentiment(ISentimentRequest request)
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
