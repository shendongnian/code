    public enum JobType
    {
        ChangeOver,
        Withdrawal,
        Installation,
    }
    // Maybe inside some DAL-pattern/database parsing class:
    var databaseToJobTypeMap = new Dictionary<string, JobType>()
    {
        { "XY01", JobType.ChangeOver },
        // ...
    };
