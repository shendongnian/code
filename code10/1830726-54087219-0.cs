    ViewBag.BackUPDestinationList = 
        ServiceBackupList.Where(x => 
             !string.IsNullOrEmpty(x.SPPServerName)).Select(...)
        .Concat(ServiceBackupList.Where(x => 
            !string.IsNullOrEmpty(x.SPServerName)).Select(...));
