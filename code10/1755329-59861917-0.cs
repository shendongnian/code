    public class HostedService: BackgroundService
    {
            private readonly ILogger _logger;
            private readonly ChannelReader<Stream> _channel;
    
            public HostedService(
                ILogger logger,
                ChannelReader<Stream> channel)
            {
                _logger = logger;
                _channel = channel;
            }
    
            protected override async Task ExecuteAsync(CancellationToken cancellationToken)
            {
                await foreach (var item in _channel.ReadAllAsync(cancellationToken))
                {
                    try
                    {
                        // do your work with data
                    }
                    catch (Exception e)
                    {
                        _logger.Error(e, "An unhandled exception occured");
                    }
                }
            }
    }
    [ApiController]
    [Route("api/data/upload")]
    public class UploadController : ControllerBase
    {
        private readonly ChannelWriter<Stream> _channel;
    
        public UploadController (
            ChannelWriter<Stream> channel)
        {
            _channel = channel;
        }
    
        public async Task<IActionResult> Upload([FromForm] FileInfo fileInfo)
        {
            var ms = new MemoryStream();
            await fileInfo.FormFile.CopyToAsync(ms);
            await _channel.WriteAsync(ms);
            return Ok();
        }
    }
