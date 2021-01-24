        private readonly IOptions<CollectionInAppSettings> _options;
		public HelloController(IOptions<CollectionInAppSettings> options)
		{
			_options = options;
		}
		[HttpGet("[action]")]
		public IActionResult IsUp()
		{
			return Ok(_options.Value);
		}
