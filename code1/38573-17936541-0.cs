        public static Task<bool> WaitForExitAsync(this Process process, TimeSpan timeout)
        {
            ManualResetEvent processWaitObject = new ManualResetEvent(false);
            processWaitObject.SafeWaitHandle = new SafeWaitHandle(process.Handle, false);
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            RegisteredWaitHandle registeredProcessWaitHandle = null;
            registeredProcessWaitHandle = ThreadPool.RegisterWaitForSingleObject(
                processWaitObject,
                delegate(object state, bool timedOut)
                {
                    if (!timedOut)
                    {
                        registeredProcessWaitHandle.Unregister(null);
                    }
                    processWaitObject.Dispose();
                    tcs.SetResult(!timedOut);
                },
                null /* state */,
                timeout,
                true /* executeOnlyOnce */);
            return tcs.Task;
        }
