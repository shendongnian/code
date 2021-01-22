    public static Boolean IsInException()
    {
       return Marshal.GetExceptionPointers() != IntPtr.Zero ||
              Marshal.GetExceptionCode() != 0;
    }
