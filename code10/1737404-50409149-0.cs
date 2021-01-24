    public Status SaveFiles(SaveDetails[] logsToSave, string destinationPath)
    {
        Status result = Status.FunctionNotAvailable;
        if (LogSaveFilesAvailable)
        {
            if (_dLogSaveFiles == null)
            {
                _dLogSaveFiles = (DLogSaveFiles)Marshal.GetDelegateForFunctionPointer(PLogSaveFiles, typeof(DLogSaveFiles));
            }
            int size = Marshal.SizeOf(typeof(SaveDetails));
            IntPtr basePtr = IntPtr.Zero;
            IntPtr[] ptrs = new IntPtr[logsToSave.Length + 1];
            try
            {
                basePtr = Marshal.AllocHGlobal(size * logsToSave.Length);
                for (int i = 0; i < logsToSave.Length; i++)
                {
                    ptrs[i] = IntPtr.Add(basePtr, (i * size));
                    Marshal.StructureToPtr(logsToSave[i], ptrs[i], false);
                }
                result = _dLogSaveFiles(ptrs, destinationPath);
            }
            finally
            {
                if (basePtr != IntPtr.Zero)
                {
                    for (int i = 0; i < logsToSave.Length; i++)
                    {
                        if (ptrs[i] != IntPtr.Zero)
                        {
                            Marshal.DestroyStructure(ptrs[i], typeof(SaveDetails));
                        }
                    }
                    Marshal.FreeHGlobal(basePtr);
                }
            }
        }
        return result;
    }
