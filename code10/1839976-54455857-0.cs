    /// <summary>
    /// Global counter that increments while the timer is active
    /// </summary>
    private TimeSpan totalElapsed = new TimeSpan(0);
    /// <summary>
    /// Save the last relevant point in time to compute the next elapsed increment
    /// </summary>
    private DateTime lastPointInTime = DateTime.MinValue;
