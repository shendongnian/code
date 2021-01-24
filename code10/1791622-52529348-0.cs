        public static class EntityFrameworkCoreSinkExtensions
        {
        public static LoggerConfiguration EntityFrameworkCoreSink(
                  this LoggerSinkConfiguration loggerConfiguration,
                  IServiceProvider serviceProvider,
                  IFormatProvider formatProvider = null)
        {
            return loggerConfiguration.Sink(new EntityFrameworkCoreSink(serviceProvider, formatProvider, 10 , TimeSpan.FromSeconds(10)));
        }
        }
