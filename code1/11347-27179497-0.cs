    public static class FileEx
    {
        public static Task CopyAsync(string sourceFileName, string destFileName)
        {
            return CopyAsync(sourceFileName, destFileName, CancellationToken.None);
        }
        public static Task CopyAsync(string sourceFileName, string destFileName, CancellationToken token)
        {
            return CopyAsync(sourceFileName, destFileName, token, null);
        }
        public static Task CopyAsync(string sourceFileName, string destFileName, IProgress<double> progress)
        {
            return CopyAsync(sourceFileName, destFileName, CancellationToken.None, progress);
        }
        public static Task CopyAsync(string sourceFileName, string destFileName, CancellationToken token, IProgress<double> progress)
        {
            int pbCancel = 0;
            CopyProgressRoutine copyProgressHandler;
            if (progress != null)
            {
                copyProgressHandler = (total, transferred, streamSize, streamByteTrans, dwStreamNumber, reason, hSourceFile, hDestinationFile, lpData) =>
                {
                    progress.Report((double)transferred / total * 100);
                    return CopyProgressResult.PROGRESS_CONTINUE;
                };
            }
            else
            {
                copyProgressHandler = EmptyCopyProgressHandler;
            }
            token.ThrowIfCancellationRequested();
            var ctr = token.Register(() => pbCancel = 1);
            var copyTask = Task.Run(() =>
            {
                try
                {
                    CopyFileEx(sourceFileName, destFileName, copyProgressHandler, IntPtr.Zero, ref pbCancel, CopyFileFlags.COPY_FILE_RESTARTABLE);
                    token.ThrowIfCancellationRequested();
                }
                finally
                {
                    ctr.Dispose();
                }
            }, token);
            return copyTask;
        }
        private static CopyProgressResult EmptyCopyProgressHandler(long total, long transferred, long streamSize, long streamByteTrans, uint dwStreamNumber, CopyProgressCallbackReason reason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData)
        {
            return CopyProgressResult.PROGRESS_CONTINUE;
        }
        #region DLL Import
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CopyFileEx(string lpExistingFileName, string lpNewFileName,
           CopyProgressRoutine lpProgressRoutine, IntPtr lpData, ref Int32 pbCancel,
           CopyFileFlags dwCopyFlags);
        delegate CopyProgressResult CopyProgressRoutine(
            long totalFileSize,
            long totalBytesTransferred,
            long streamSize,
            long streamBytesTransferred,
            uint dwStreamNumber,
            CopyProgressCallbackReason dwCallbackReason,
            IntPtr hSourceFile,
            IntPtr hDestinationFile,
            IntPtr lpData);
        enum CopyProgressResult : uint
        {
            PROGRESS_CONTINUE = 0,
            PROGRESS_CANCEL = 1,
            PROGRESS_STOP = 2,
            PROGRESS_QUIET = 3
        }
        enum CopyProgressCallbackReason : uint
        {
            CALLBACK_CHUNK_FINISHED = 0x00000000,
            CALLBACK_STREAM_SWITCH = 0x00000001
        }
        [Flags]
        enum CopyFileFlags : uint
        {
            COPY_FILE_FAIL_IF_EXISTS = 0x00000001,
            COPY_FILE_RESTARTABLE = 0x00000002,
            COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,
            COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008
        }
        #endregion
    }
