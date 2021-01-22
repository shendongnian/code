    using System.Reflection;
    public static class MethodInfoHelper
    {
        /// <summary>
        ///     Detects whether the given method is overridden.
        /// </summary>
        /// <param name="methodInfo">The method to inspect.</param>
        /// <returns><see langword="true" /> if method is overridden, otherwise <see langword="false" /></returns>
        public static bool IsOverridden(this MethodInfo methodInfo)
        {
            return methodInfo.DeclaringType == methodInfo.ReflectedType
                   && !methodInfo.IsAbstract;
        }
    }
