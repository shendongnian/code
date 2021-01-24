            public class ParameterActionFilter : IActionFilter
        {
            private readonly ILogger _logger;
            private readonly string _para1;
            private readonly string _para2;
            public ParameterActionFilter(ILoggerFactory loggerFactory, string para1, string para2)
            {
                _logger = loggerFactory.CreateLogger<ParameterTypeFilter>();
                _para1 = para1;
                _para2 = para2;
            }
            public void OnActionExecuting(ActionExecutingContext context)
            {
                _logger.LogInformation($"Parameter One is {_para1}");
                // perform some business logic work
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
                // perform some business logic work
                _logger.LogInformation($"Parameter Two is {_para2}");
            }
        }
