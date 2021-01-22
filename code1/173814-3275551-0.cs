    private class FileCopy
    {
        private bool cancel = false;
        public void Copy(string existingFile, string newFile)
        {
            if (!CopyFileEx(existingFile, newFile, 
                CancelableCopyProgressRoutine, IntPtr.Zero, IntPtr.Zero, 0))
            {
                throw new Win32Exception();
            }
        }
        public void Abort()
        {
            cancel = true;
        }
        private CopyProgressResult CancelableCopyProgressRoutine(
            long TotalFileSize,
            long TotalBytesTransferred,
            long StreamSize,
            long StreamBytesTransferred,
            uint dwStreamNumber,
            CopyProgressCallbackReason dwCallbackReason,
            IntPtr hSourceFile,
            IntPtr hDestinationFile,
            IntPtr lpData)
        {
            return cancel ? CopyProgressResult.PROGRESS_CANCEL : 
                CopyProgressResult.PROGRESS_CONTINUE;
        }
        // Include p/inovke definitions from 
        // http://www.pinvoke.net/default.aspx/kernel32.copyfileex here
    }
