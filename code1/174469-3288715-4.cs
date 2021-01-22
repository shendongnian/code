	[Serializable]
    public sealed class LoggingAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs eventArgs)
        {
			Console.WriteLine("Entering {0} {1} {2}",
                              eventArgs.Method.ReflectedType.Name,
                              eventArgs.Method,
                              string.Join(", ", eventArgs.Arguments.ToArray()));
            eventArgs.MethodExecutionTag = DateTime.Now.Ticks;
        }
        public override void OnExit(MethodExecutionArgs eventArgs)
        {
            long elapsedTicks = DateTime.Now.Ticks - (long) eventArgs.MethodExecutionTag;
            TimeSpan ts = TimeSpan.FromTicks(elapsedTicks);
			Console.WriteLine("Leaving {0} {1} after {2}ms",
                              eventArgs.Method.ReflectedType.Name,
                              eventArgs.Method,
                              ts.TotalMilliseconds);
        }
    }
