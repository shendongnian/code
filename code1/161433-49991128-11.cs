    public static class Require
    {
        [ContractAnnotation("condition:false => halt")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerHidden]
        public static void True(bool condition)
        {
            if (!condition)
            {
                throw ExceptionHelpers.InvalidOperation($"Expected condition was not met.");
            }
        }
    }
