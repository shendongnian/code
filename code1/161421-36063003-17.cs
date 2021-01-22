    public static class ExceptionExtensions
    {
        public static string GetStackTraceWithoutHiddenMethods(this Exception e)
        {
            return string.Concat(
               new StackTrace(e, true)
                   .GetFrames()
                   .Where(frame => !frame.GetMethod().IsDefined(typeof(StackTraceHiddenAttribute), true))
                   .Select(frame => new StackTrace(frame).ToString())
                   .ToArray());
        }                         
    }
