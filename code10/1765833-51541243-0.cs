    var troposLogs = new List<TroposLog>();
    var log = new TroposLog();
    log.Created = DateTime.ParseExact("2018.07.26 10:35:06:7889", @"yyyy\.MM\.dd HH\:mm\:ss\:ffff", CultureInfo.InvariantCulture);
    log.SessionId = "4d50b064-d269-4256-a187-82a3f9402735";
    log.Message = "Client successfully got the transaction result";
    troposLogs.Add(log);
    log = new TroposLog();
    log.Created = DateTime.ParseExact("2018.07.26 10:35:07:1219", @"yyyy\.MM\.dd HH\:mm\:ss\:ffff", CultureInfo.InvariantCulture);
    log.SessionId = "4d50b064-d269-4256-a187-82a3f9402735";
    log.Message = "Start Session ThreadSuccess (c0c2311a-b509-4e6e-a236-80e2d86f2647)";
    log.UserName = "DAIW";
    troposLogs.Add(log);
    log = new TroposLog();
    log.Created = DateTime.ParseExact("2018.07.26 10:35:06:9169", @"yyyy\.MM\.dd HH\:mm\:ss\:ffff", CultureInfo.InvariantCulture);
    log.SessionId = "4d50b064-d269-4256-a187-82a3f9402735";
    log.Message = "Run Transaction Thread (SOCS)... Success";
    log.ActionName = "SOCS";
    troposLogs.Add(log);
    var ordered = troposLogs.OrderBy(m => m.UserName == null)
                .ThenBy(m => m.UserName)
                .ThenBy(m => m.SessionId)
                .ThenBy(m => m.Created)
                .ToArray();
