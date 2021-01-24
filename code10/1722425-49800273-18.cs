    static string GetBuildMonthDay()
    {
        var version = typeof(Test).GetTypeInfo().Assembly.GetName().Version;
        var buildDateTime = new DateTime(2000, 1, 1)
            .AddDays(version.Build)
            .AddSeconds(version.Revision * 2);
        return buildDateTime.ToString("Mdd", CultureInfo.InvariantCulture);
    }
