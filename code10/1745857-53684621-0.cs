    /// <summary>
    /// Triggered when the application host is performing a graceful shutdown.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
    public virtual async Task StopAsync(CancellationToken cancellationToken)
    {
      if (this._executingTask == null)
        return;
      try
      {
        this._stoppingCts.Cancel();
      }
      finally
      {
        Task task = await Task.WhenAny(this._executingTask, Task.Delay(-1, cancellationToken));
      }
    }
