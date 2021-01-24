    [HttpPost]
    public IActionResult Post([FromBodyCustomSerializationSettings]MyPostDto postDto)
    {
        ...
    }
    class FromBodyCustomSerializationSettingsAttribute : ModelBinderAttribute
    {
        public FromBodyCustomSerializationSettingsAttribute() : base(typeof(MyModelBinder))
        {
            BindingSource = BindingSource.Body;
        }
    }
    class MyModelBinder : IModelBinder
    {
        private readonly BodyModelBinder _bodyModelBinder;
        public MyModelBinder(IHttpRequestStreamReaderFactory readerFactory, ILoggerFactory loggerFactory, IOptions<MvcOptions> options, IOptions<MvcJsonOptions> jsonOptions, ArrayPool<char> charPool, ObjectPoolProvider objectPoolProvider)
        {
            var formatters = options.Value.InputFormatters.ToList();
            int jsonFormatterIndex = formatters.FirstIndexOf(formatter => formatter is JsonInputFormatter);
            JsonSerializerSettings myCustomSettings = ...
            formatters[jsonFormatterIndex] = new JsonInputFormatter(loggerFactory.CreateLogger("MyCustomJsonFormatter"), myCustomSettings, charPool, objectPoolProvider, options.Value, jsonOptions.Value);
            _bodyModelBinder = new BodyModelBinder(formatters, readerFactory, loggerFactory, options.Value);
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            return _bodyModelBinder.BindModelAsync(bindingContext);
        }
    }
