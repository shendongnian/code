    public void Dispose()
    {
        bool ExceptionOccurred = Marshal.GetExceptionPointers() != IntPtr.Zero
                                 || Marshal.GetExceptionCode() != 0;
        if(ExceptionOccurred)
        {
            System.Diagnostics.Debug.WriteLine("We had an exception");
        }
    }
