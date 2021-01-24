            var global = GlobalTest.Get();
            LoggerManager.LogInfo($"Global LastProcessDay : {global.LastProcessDay} - {DateTime.UtcNow}");
            global.LastProcessDay = DateTime.Now.AddDays(10).ToString("yyyy-MM-ddThhh:mmm:ssZ");
            global.Save();
            global = GlobalTest.Get();
            LoggerManager.LogInfo($"Global LastProcessDay : {global.LastProcessDay} - {DateTime.UtcNow}");
