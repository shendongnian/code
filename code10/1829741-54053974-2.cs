     set {
            if (!Enum.IsDefined(typeof(ProcessPriorityClass), value)) { 
                throw new InvalidEnumArgumentException("value", (int)value, typeof(ProcessPriorityClass));
            }
 
            // BelowNormal and AboveNormal are only available on Win2k and greater.
            if (((value & (ProcessPriorityClass.BelowNormal | ProcessPriorityClass.AboveNormal)) != 0)   && 
                (OperatingSystem.Platform != PlatformID.Win32NT || OperatingSystem.Version.Major < 5)) {
                throw new PlatformNotSupportedException(SR.GetString(SR.PriorityClassNotSupported), null);
            }                
                                
            SafeProcessHandle handle = null;
 
            try {
                handle = GetProcessHandle(NativeMethods.PROCESS_SET_INFORMATION);
                if (!NativeMethods.SetPriorityClass(handle, (int)value)) {
                    throw new Win32Exception();
                }
                priorityClass = value;
                havePriorityClass = true;
            }
            finally {
                ReleaseProcessHandle(handle);
            }
        }
