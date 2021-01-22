    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    [AttributeUsage(AttributeTargets.Method, Inherited=false)]
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
            return string.Concat(
                new StackTrace(e, true)
                    .GetFrames()
                    .Where(frame => !frame.GetMethod().ShouldHideFromStackTrace())
                    .Select(frame => new StackTrace(frame).ToString())
                    .ToArray());  // ^^^^^^^^^^^^^^^     ^
        }                         // required because you want the usual stack trace
    }                             // formatting; StackFrame.ToString() formats differently
