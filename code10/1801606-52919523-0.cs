    if (ttl.Timespan > TimeSpan.Zero && result != null && !result.Equals(default(TResult)))
      {
      try
      {
          await cacheProvider.PutAsync(cacheKey, result, ttl, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
          onCachePut(context, cacheKey);
      }
      catch (Exception ex)
      {
           onCachePutError(context, cacheKey, ex);
      }
    }
