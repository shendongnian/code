    public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                using(var scope = _container.CreateScope())
                {
                    var res = scope.ServiceProvider.GetService(bundle.JobDetail.JobType) as IJob;
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
