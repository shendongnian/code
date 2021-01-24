			logBuilder.AddFilter((provider, category, logLevel) =>
			{
				if (provider == "Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider" && 
					category == "TodoApiSample.Controllers.TodoController")
				{
					return false;
				}
				return true;
			});
		})
		.Build();
