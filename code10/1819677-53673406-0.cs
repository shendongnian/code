    public class StreamedDatabaseObjectResult : ActionResult
    {
        private readonly Func<Task<DisposableEnumerable>> _getValuesFunc;
        public StreamedDatabaseObjectResult(Func<Task<DisposableEnumerable>> getValuesFunc)
        {
            _getValuesFunc = getValuesFunc;
        }
        public override async Task ExecuteResultAsync(ActionContext context)
        {
            using (var de = await _getValuesFunc())
            {
                var objectResult = new ObjectResult(de.Values);
                await objectResult.ExecuteResultAsync(context);
            }
        }
    }
    public class DisposableEnumerable : IDisposable
    {
        public IEnumerable Values { get; }
        private readonly IDisposable _disposable;
        public DisposableEnumerable(IDisposable disposable, IEnumerable values)
        {
            Values = values;
            _disposable = disposable;
        }
        /// <inheritdoc />
        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
    [HttpGet]
    [ProducesResponseType(200)]
    public ActionResult<IEnumerable<MyClass>> GetThings(CancellationToken cancellationToken)
    {
        return new StreamedDatabaseObjectResult(() => _repo.GetThings(cancellationToken));
    }
