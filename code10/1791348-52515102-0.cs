            public ISentimentResponse AnalyseSentiment(ISentimentRequest request, SentimentEngineServices selectedEngines)
            {
                if (selectedEngines == SentimentEngineServices.None) throw new ArgumentException(nameof(selectedEngines));
                ValidateRequest(request);
                return ProcessRequestAsync(request, selectedEngines).Result;
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
                    foreach (var result in results)
                        response.Add(result);
                }
                return response;
            }
