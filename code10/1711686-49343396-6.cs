    using System.Linq;
    using NLog;
    using NLog.Layouts;
    using NLog.Targets;
    internal class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static void Main(string[] args)
        {
            for (var i = 0; i < 2; i++)
            {                
                if (i % 2 == 0)
                {
                    Logger.Info("normal log message");
                }
                else
                {
                    // reconfigure
                    var consoleTarget = LogManager.Configuration.FindTargetByName<ColoredConsoleTarget>("logconsole");
                    var oldLayout = consoleTarget.Layout;
                    consoleTarget.Layout = new SimpleLayout { Text = "${uppercase:${level}}: ${message} ${exception:format=tostring}" };
                    var fileRule = LogManager.Configuration.LoggingRules.Single(r => r.Targets.Any(t => t.Name == "logfile"));
                    LogManager.Configuration.LoggingRules.Remove(fileRule);
                    LogManager.Configuration.Reload();
                    Logger.Info("special case");
                    // replace originals
                    consoleTarget.Layout = oldLayout;
                    LogManager.Configuration.LoggingRules.Add(fileRule);
                    LogManager.Configuration.Reload();
                }
            }
        }
    }
