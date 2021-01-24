     private readonly ILogger _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            _logger.LogInformation("Log Information");
            _logger.LogWarning("Log Warning");
        }
