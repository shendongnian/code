    [Test]
    public void Load()
    {
        XmlConfigurator.Configure();
        var fileAppender = LogManager.GetRepository()
            .GetAppenders().First(appender => appender is RollingFileAppender);
        var expectedFile = 
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "test.txt");
        Assert.That(fileAppender, 
            Is.Not.Null & Has.Property("File").EqualTo(expectedFile));
    }
