    public static bool ReadMemory(Process process, IntPtr address, ref int result)
    {
       result = 100;
       return true;
    }
    public static bool ReadMemory(Process process, IntPtr address, ref float result)
    {
       result = 100.0f;
       return true;
    }
