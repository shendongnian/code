    [TestFixture]
    public WorkerTests
    {
      [Test]
      public void Execute_ConfigurationFileNotFound_LogsException()
      {
         var config = Substitute.For<IConfiguration>();
         var filesystem = Substitute.For<IFileSystem>();
         var log = Substitute.For<ILog>();
         var datetime = Substitute.For<IConfiIDateTimeFactory>();
         var worker = new Worker(
           config,
           filesystem,
           log,
           datetime)
         // setup the mock'd file system to always return false for Exists()
         // That is what we're testing
         filesystem.Exists(string.Empty).ReturnsForAnyArgs(false);
         worker.Execute();
         log.Received().Fatal();
      }
    }
