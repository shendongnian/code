    // returns true if the dll is 64-bit, false if 32-bit, and null if unknown
    public static bool? UnmanagedDllIs64Bit(string dllPath)
    {
      switch (GetDllMachineType(dllPath))
      {
        case MachineType.IMAGE_FILE_MACHINE_AMD64:
        case MachineType.IMAGE_FILE_MACHINE_IA64:
          return true;
        case MachineType.IMAGE_FILE_MACHINE_I386:
          return false;
        default:
          return null;
      }
    }
