     public async Task RegisterJobsProcessAsync(Task<IScheduler> scheduler)
            {
                _log.Info("Job registering process begins");
    
                this._scheduler = scheduler.Result;
    
                await UnRegisterJobsAsync();
                await RegisterJobsAsync();
    
                _log.Info("Job registering process ends");
            }
