    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    [AttributeUsage(AttributeTargets.Method)]
    public class HideFromStackTraceAttribute : Attribute { }
    
    public static class MethodBaseExtensions
    {
        public static bool ShouldHideFromStackTrace(this MethodBase method)
        {
            return method.IsDefined(typeof(HideFromStackTraceAttribute), true);
        }
    }
    
    public static class ExceptionExtensions
    {
        public static string GetStackTraceWithoutHiddenMethods(this Exception e)
        {
            return string.Join(
                Environment.NewLine,
                new StackTrace(e, true)
                    .GetFrames()
                    .Where(frame => !frame.GetMethod().ShouldHideFromStackTrace())
                    .Select(frame => frame.ToString())
                    .ToArray());  // ^^^^^^^^^^^^^^^^
        }                         // output format will look different from e.StackTrace;
    }                             // you might want to improve this a little.
