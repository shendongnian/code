    public static class MethodInfoUtil
    {
        public static bool IsOverride(this MethodInfo methodInfo)
        {
            return (methodInfo.GetBaseDefinition() != methodInfo);
        }
    }
