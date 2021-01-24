    long originalTicks = testData.Ticks;
    long hoursSinceEpoch = originalTicks / TimeSpan.TicksPerHour;
    long newTicks = hoursSinceEpoch * TimeSpan.TicksPerHour;
    return new DateTime(newTicks, testData.Kind);
    
