        [AutomaticRetry(Attempts = 0)]
        [DisplayName("InvokeApi,apiUrl:{0}")]
        public void InvokeApi(string apiUrl, PerformContext context)
        {
            var invocationData = InvocationData.Serialize(context.BackgroundJob.Job);
            int.TryParse(context?.BackgroundJob.Id, out var jobId);
            var dtBegin = DateTimeOffset.Now;
            var client = new RestClient(apiUrl)
            {
                Timeout = -1,
                ReadWriteTimeout = -1
            };
            var request = new RestRequest(Method.GET)
            {
                Timeout = -1,
                ReadWriteTimeout = -1
            };
            client.ExecuteAsync(request, response => {
                if (!response.IsSuccessful)
                {
                    var responseMessage = $"TotalSeconds={DateTimeOffset.Now.Subtract(dtBegin).TotalSeconds},StatusDescription={response.StatusDescription},ErrorMessage={response.ErrorMessage ?? "null"}";
                    try
                    {
                        var strHangfireDataContext = EngineContext.Instance.ServiceProvider.GetService<ConnectionStringsConfiguration>().HangfireDataContext;
                        var optionsBuilder = new DbContextOptionsBuilder<HangfireContext>();
                        optionsBuilder.UseSqlServer(strHangfireDataContext);
                        using (var dbContext = new HangfireContext(optionsBuilder.Options))
                        {
                            using (var transaction = dbContext.Database.BeginTransaction())
                            {
                                var state = dbContext.State.FirstOrDefault(x =>
                                    x.JobId == jobId && x.Name == "Succeeded");
                                if (state != null)
                                {
                                    var failedState = new FailedState(new Exception(responseMessage));
                                    state.Name = failedState.Name;
                                    state.Reason = failedState.Reason;
                                    state.Data = JobHelper.ToJson(failedState.SerializeData());
                                }
                                var job = dbContext.Job.FirstOrDefault(x => x.Id == jobId);
                                if (job != null)
                                {
                                    job.StateName = "Failed";
                                    job.InvocationData = JobHelper.ToJson(new
                                    {
                                        Type = invocationData.Type,
                                        Method = invocationData.Method,
                                        ParameterTypes = invocationData.ParameterTypes,
                                        Arguments = invocationData.Arguments
                                    });
                                }
                                var counter =
                                    dbContext.AggregatedCounter.FirstOrDefault(x => x.Key == "stats:succeeded");
                                if (counter != null) counter.Value = counter.Value - 1;
                                dbContext.SaveChanges();
                                transaction.Commit();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Exception jobId:" + jobId + ";ex:" + ex.ToString());
                    }
                }
            });
        }
