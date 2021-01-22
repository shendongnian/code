    var version = Assembly.GetEntryAssembly().GetName().Version;
    var buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(
    TimeSpan.TicksPerDay * version.Build + // days since 1 January 2000
    TimeSpan.TicksPerSecond * 2 * version.Revision)); /* seconds since midnight,
                                                         (multiply by 2 to get original) */
