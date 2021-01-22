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
                new StackTrace(e)
                    .GetFrames()
                    .Where(frame => !frame.GetMethod().ShouldHideFromStackTrace())
                    .Select(frame => frame.ToString())
                    .ToArray());  // ^^^^^^^^^^^^^^^^
        }                         // this doesn't seem to work too well, btw.
    }
