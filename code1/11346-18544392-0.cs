        /// <summary>
        /// Type indicates how the copy gets completed.
        /// </summary>
        internal enum CopyCompletedType
        {
            Succeeded,
            Aborted,
            Exception
        }
    /// <summary>
    /// Event arguments for file copy 
    /// </summary>
    internal class FileCopyEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">type of the copy completed type enum</param>
        /// <param name="exception">exception if any</param>
        public FileCopyEventArgs(CopyCompletedType type, Exception exception)
        {
            Type = type;
            Exception = exception;
        }
        /// <summary>
        /// Type of the copy completed type
        /// </summary>
        public CopyCompletedType Type
        {
            get;
            private set;
        }
        /// <summary>
        /// Exception if any happend during copy.
        /// </summary>
        public Exception Exception
        {
            get;
            private set;
        }
    }
    /// <summary>
    /// PInvoke wrapper for CopyEx
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa363852.aspx
    /// </summary>
    internal class XCopy
    {
        private int IsCancelled;
        private int FilePercentCompleted;
        public XCopy()
        {
            IsCancelled = 0;
        }
        /// <summary>
        /// Copies the file asynchronously
        /// </summary>
        /// <param name="source">the source path</param>
        /// <param name="destination">the destination path</param>
        /// <param name="nobuffering">Bufferig status</param>
        /// <param name="handler">Event handler to do file copy.</param>
        public void CopyAsync(string source, string destination, bool nobuffering)
        {
            try
            {
                //since we needed an async copy ..
                Action action = new Action(
                    () => CopyInternal(source, destination, nobuffering)
                        );
                Task task = new Task(action);
                task.Start();
            }
            catch (AggregateException ex)
            {
                //handle the inner exception since exception thrown from task are wrapped in
                //aggreate exception.
                OnCompleted(CopyCompletedType.Exception, ex.InnerException);
            }
            catch (Exception ex)
            {
                OnCompleted(CopyCompletedType.Exception, ex);
            }
        }
        /// <summary>
        /// Event which will notify the subscribers if the copy gets completed
        /// There are three scenarios in which completed event will be thrown when
        /// 1.Copy succeeded
        /// 2.Copy aborted.
        /// 3.Any exception occured.
        /// These information can be obtained from the Event args.
        /// </summary>
        public event EventHandler<FileCopyEventArgs> Completed;
        /// <summary>
        /// Event which will notify the subscribers if there is any progress change while copying.
        /// This will indicate the progress percentage in its event args.
        /// </summary>
        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;
        /// <summary>
        /// Aborts the copy asynchronously and throws Completed event when done.
        /// User may not want to wait for completed event in case of Abort since 
        /// the event will tell that copy has been aborted.
        /// </summary>
        public void AbortCopyAsync()
        {
            Trace.WriteLine("Aborting the copy");
            //setting this will cancel an operation since we pass the
            //reference to copyfileex and it will periodically check for this.
            //otherwise also We can check for iscancelled on onprogresschanged and return 
            //Progress_cancelled .
            IsCancelled = 1;
            Action completedEvent = new Action(() =>
                {
                    //wait for some time because we ll not know when IsCancelled is set , at what time windows stops copying.
                    //so after sometime this may become valid .
                    Thread.Sleep(500);
                    //do we need to wait for some time and send completed event.
                    OnCompleted(CopyCompletedType.Aborted);
                    //reset the value , otherwise if we try to copy again since value is 1 , 
                    //it thinks that its aborted and wont allow to copy.
                    IsCancelled = 0;
                });
            Task completedTask = new Task(completedEvent);
            completedTask.Start();
        }
        /// <summary>
        /// Copies the file using asynchronos task
        /// </summary>
        /// <param name="source">the source path</param>
        /// <param name="destination">the destination path</param>
        /// <param name="nobuffering">Buffering status</param>
        /// <param name="handler">Delegate to handle Progress changed</param>
        private void CopyInternal(string source, string destination, bool nobuffering)
        {
            CopyFileFlags copyFileFlags = CopyFileFlags.COPY_FILE_RESTARTABLE;
            if (nobuffering)
            {
                copyFileFlags |= CopyFileFlags.COPY_FILE_NO_BUFFERING;
            }
            try
            {
                Trace.WriteLine("File copy started with Source: " + source + " and destination: " + destination);
                //call win32 api.
                bool result = CopyFileEx(source, destination, new CopyProgressRoutine(CopyProgressHandler), IntPtr.Zero, ref IsCancelled, copyFileFlags);
                if (!result)
                {
                    //when ever we get the result as false it means some error occured so get the last win 32 error.
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
            catch (Exception ex)
            {
                //the mesage will contain the requested operation was aborted when the file copy
                //was cancelled. so we explicitly check for that and do a graceful exit
                if (ex.Message.Contains("aborted"))
                {
                    Trace.WriteLine("Copy aborted.");
                }
                else
                {
                    OnCompleted(CopyCompletedType.Exception, ex.InnerException);
                }
            }
        }
        private void OnProgressChanged(double percent)
        {
            // only raise an event when progress has changed
            if ((int)percent > FilePercentCompleted)
            {
                FilePercentCompleted = (int)percent;
                var handler = ProgressChanged;
                if (handler != null)
                {
                    handler(this, new ProgressChangedEventArgs((int)FilePercentCompleted, null));
                }
            }
        }
        private void OnCompleted(CopyCompletedType type, Exception exception = null)
        {
            var handler = Completed;
            if (handler != null)
            {
                handler(this, new FileCopyEventArgs(type, exception));
            }
        }
        #region PInvoke
        /// <summary>
        /// Delegate which will be called by Win32 API for progress change
        /// </summary>
        /// <param name="total">the total size</param>
        /// <param name="transferred">the transferrred size</param>
        /// <param name="streamSize">size of the stream</param>
        /// <param name="streamByteTrans"></param>
        /// <param name="dwStreamNumber">stream number</param>
        /// <param name="reason">reason for callback</param>
        /// <param name="hSourceFile">the source file handle</param>
        /// <param name="hDestinationFile">the destination file handle</param>
        /// <param name="lpData">data passed by users</param>
        /// <returns>indicating whether to continue or do somthing else.</returns>
        private CopyProgressResult CopyProgressHandler(long total, long transferred, long streamSize, long streamByteTrans, uint dwStreamNumber,
                                                       CopyProgressCallbackReason reason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData)
        {
            //when a chunk is finished call the progress changed.
            if (reason == CopyProgressCallbackReason.CALLBACK_CHUNK_FINISHED)
            {
                OnProgressChanged((transferred / (double)total) * 100.0);
            }
            //transfer completed
            if (transferred >= total)
            {
                if (CloseHandle(hDestinationFile))
                {
                    OnCompleted(CopyCompletedType.Succeeded, null);
                }
                else
                {
                    OnCompleted(CopyCompletedType.Exception,
                        new System.IO.IOException("Unable to close the file handle"));
                }
            }
            return CopyProgressResult.PROGRESS_CONTINUE;
        }
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CopyFileEx(string lpExistingFileName, string lpNewFileName, CopyProgressRoutine lpProgressRoutine, IntPtr lpData, ref Int32 pbCancel, CopyFileFlags dwCopyFlags);
        private delegate CopyProgressResult CopyProgressRoutine(long TotalFileSize, long TotalBytesTransferred, long StreamSize, long StreamBytesTransferred, uint dwStreamNumber, CopyProgressCallbackReason dwCallbackReason,
                                                        IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData);
        private enum CopyProgressResult : uint
        {
            PROGRESS_CONTINUE = 0,
            PROGRESS_CANCEL = 1,
            PROGRESS_STOP = 2,
            PROGRESS_QUIET = 3
        }
        private enum CopyProgressCallbackReason : uint
        {
            CALLBACK_CHUNK_FINISHED = 0x00000000,
            CALLBACK_STREAM_SWITCH = 0x00000001
        }
        [Flags]
        private enum CopyFileFlags : uint
        {
            COPY_FILE_FAIL_IF_EXISTS = 0x00000001,
            COPY_FILE_NO_BUFFERING = 0x00001000,
            COPY_FILE_RESTARTABLE = 0x00000002,
            COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,
            COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008
        }
        #endregion
    }
