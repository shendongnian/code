    public static class ManagedMethods
    {
        public static string ErrorMessage(ErrorCode errorCode)
        {
            return NativeMethods.errMessage((int)errorCode);
        }
    }
