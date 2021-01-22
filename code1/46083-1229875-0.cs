    internal class LogModule : StandardModule
        {
            private class log4netILogProvider : SimpleProvider<log4net.ILog>
            {
                protected override ILog CreateInstance(IContext context)
                {
                    return LogManager.GetLogger(context.Instance.GetType());
                }
            }
    
            public override void Load()
            {
                Bind<log4net.ILog>().ToProvider(new log4netILogProvider());
            }
        }
