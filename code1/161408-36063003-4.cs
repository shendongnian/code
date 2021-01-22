    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public sealed class StackTraceHiddenAttribute : Attribute
    {
    }
    public class SomeException : Exception
    {
        public override string StackTrace
        {
            get
            {
                return string.Concat(
                    new StackTrace(this, true)
                        .GetFrames()
                        .Where(frame => !frame.GetMethod().IsDefined(typeof(StackTraceHiddenAttribute), true))
                        .Select(frame => new StackTrace(frame).ToString())
                        .ToArray());
            }
        }
    }
