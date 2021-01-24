        protected async override Task ExecuteAsync(
            CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    foreach (var ext in GetExtensions())
                    {
                        //Oops, time to cancel
                        if(cancellationToken.IsCancellationRequested)
                        {
                            break;
                        }
                        //Otherwise, keep working
                        ext.Status = StatusType.Available;
                    }
                    await Task.Delay(1000,cancellationToken);
                }
                catch (Exception ex)
                {
                    ...
                }
            }
            _logger.LogInformation("Hosted Service is stopping.");
        }        
