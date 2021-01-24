    public async Task StopAsync(CancellationToken cancellationToken)
        {
    try
            {
                await Task.Delay(Timeout.Infinite, cancellationToken);
            }
            catch(TaskCanceledException)
            {
                _logger.LogDebug("TaskCanceledException in StopAsync");
                // do not rethrow
            }
        }
