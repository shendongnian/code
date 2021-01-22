    var service = AutogateProcessorService.GetInstance();
    var allConfigs = service.GetAll();
    allConfigs = allConfigs.OrderBy(c => c.ThreadDescription).ToList();
    var systemQueue = allConfigs.First(c => c.AcquirerId == 0);
    allConfigs.Remove(systemQueue);
    allConfigs.Insert(0, systemQueue);
