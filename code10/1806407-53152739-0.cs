    internal static class LoggerImpl
    {
        internal static void Write([NotNull] Type loggerType, TargetWithFilterChain targets, LogEventInfo logEvent, LogFactory factory)
        {
            if (targets == null)
                return;
            StackTraceUsage stu = targets.GetStackTraceUsage();
            if (stu != StackTraceUsage.None && !logEvent.HasStackTrace)
            {
                var stackTrace = new StackTrace(StackTraceSkipMethods, stu == StackTraceUsage.WithSource);
                var stackFrames = stackTrace.GetFrames();
                int? firstUserFrame = FindCallingMethodOnStackTrace(stackFrames, loggerType);
                int? firstLegacyUserFrame = firstUserFrame.HasValue ? SkipToUserStackFrameLegacy(stackFrames, firstUserFrame.Value) : (int?)null;
                logEvent.GetCallSiteInformationInternal().SetStackTrace(stackTrace, firstUserFrame ?? 0, firstLegacyUserFrame);
            }
            // ...
        }
    }
