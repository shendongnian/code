    private TimeSpan GetServerRecommendedPause(HttpResponseMessage response)
        {
            var retryAfter = response?.Headers?.RetryAfter;
            if (retryAfter == null)
                return TimeSpan.Zero;
            return retryAfter.Date.HasValue
                ? retryAfter.Date.Value - DateTime.UtcNow
                : retryAfter.Delta.GetValueOrDefault(TimeSpan.Zero);
        }
