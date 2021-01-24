    [Test]
    public void PassLoggerToHandlersCtor()
    {
        // Arrange
        var builder = new ContainerBuilder();
        builder.RegisterType<Logger>().As<ILogger>();
        builder.RegisterType<Files>().As<IHttpHandler>();
        builder.RegisterType<FileService>().AsSelf();
        var container = builder.Build();
        // Act
        var handler = container.Resolve<IHttpHandler>();
        // Assert
        Assert.IsInstanceOf<Files>(handler);
        var files = (Files) handler;
        Assert.IsInstanceOf<Logger>(files.Logger);
        Assert.IsInstanceOf<Logger>(files.fileService.Logger);
    }
    public class Files : IHttpHandler
    {
        /// <summary>
        /// Just for tests
        /// </summary>
        public ILogger Logger { get; }
        /// <summary>
        /// Just for tests
        /// </summary>
        public FileService fileService { get; }
        /// <inheritdoc />
        public bool IsReusable { get; }
        public Files(ILogger logger)
        {
            Logger = logger;
            fileService = new FileService(logger);
        }
        /// <inheritdoc />
        public void ProcessRequest(HttpContext context)
        {
                
        }
    }
    public interface ILogger { }
    public class Logger : ILogger { }
    public class FileService
    {
        /// <summary>
        /// Just for tests
        /// </summary>
        public ILogger Logger { get; }
        public FileService(Program.ILogger logger)
        {
            Logger = logger;
        }
    }
