    internal abstract class TestModeDetector
    {
        internal abstract bool RunningInUnitTest();
        internal static TestModeDetector GetInstance()
        {
        #if DEBUG
            return new DebugImplementation();
        #else
            return new ReleaseImplementation();
        #endif
        }
        private class ReleaseImplementation : TestModeDetector
        {
            internal override bool RunningInUnitTest()
            {
                return false;
            }
        }
        private class DebugImplementation : TestModeDetector
        {
            private Mode mode_;
            internal override bool RunningInUnitTest()
            {
                if (mode_ == Mode.Unknown)
                {
                    mode_ = DetectMode();
                }
                return mode_ == Mode.Test;
            }
            private Mode DetectMode()
            {
                return HasUnitTestInStack(new StackTrace()) ? Mode.Test : Mode.Regular;
            }
            private static bool HasUnitTestInStack(StackTrace callStack)
            {
                return GetStackFrames(callStack).SelectMany(stackFrame => stackFrame.GetMethod().GetCustomAttributes(false)).Any(NunitAttribute);
            }
            private static IEnumerable<StackFrame> GetStackFrames(StackTrace callStack)
            {
                return callStack.GetFrames() ?? new StackFrame[0];
            }
            private static bool NunitAttribute(object attr)
            {
                var type = attr.GetType();
                if (type.FullName != null)
                {
                    return type.FullName.StartsWith("nunit.framework", StringComparison.OrdinalIgnoreCase);
                }
                return false;
            }
            private enum Mode
            {
                Unknown,
                Test,
                Regular
            }
