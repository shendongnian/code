    #load "Integration.csx"
    
    using System;
    
    public static void Run(TimerInfo myTimer, TraceWriter log)
    {
        Integration.ImportRosters(
            log: s => log.Info(s),
            connectionString: "conString",
            siteID: 5,
            nowUtc: DateTime.UtcNow,
            actualDays: 7,
            rosterDays: 7     
        );
        log.Info($"Import Roster Data function executed at: {DateTime.Now}");
    }
