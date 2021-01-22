    [Test]
    public void Log4net_WritesToDisk()
    {
        var expectedFile = 
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.CommonApplicationData),
                    "test.txt");
        if (File.Exists(expectedFile))
            File.Delete(expectedFile);
            
        XmlConfigurator.Configure();
        var log = LogManager.GetLogger(typeof (ConfigTest));
        log.Info("Message from test");
        LogManager.Shutdown();
        Assert.That(File.ReadAllText(expectedFile), 
            Text.Contains("Message from test"));
    }
