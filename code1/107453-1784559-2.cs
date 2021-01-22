        private const uint LOCKFILE_EXCLUSIVE_LOCK = 0x00000002;
        private static readonly Action WinIOError;
        static Win32Native()
        {
            BindingFlags bindingAttr = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            var winIOErrorMethod = typeof(string).Assembly.GetType("System.IO.__Error").GetMethod("WinIOError", bindingAttr, null, Type.EmptyTypes, null);
            WinIOError = (Action)Delegate.CreateDelegate(typeof(Action), winIOErrorMethod);
        }
        public static void LockFile(SafeFileHandle handle, bool exclusive, long offset, long length, Action action)
        {
            if (handle == null)
                throw new ArgumentNullException("handle");
            if (handle.IsInvalid)
                throw new ArgumentException("An invalid file handle was specified.", "handle");
            if (offset < 0)
                throw new ArgumentOutOfRangeException("The offset cannot be negative.", "offset");
            if (length < 0)
                throw new ArgumentOutOfRangeException("The length cannot be negative.", "length");
            if (action == null)
                throw new ArgumentNullException("action");
            LockFileUnsafe(handle, exclusive, offset, length, action);
        }
        private static unsafe void LockFileUnsafe(SafeFileHandle handle, bool exclusive, long offset, long length, Action action)
        {
            Overlapped overlapped = new Overlapped();
            overlapped.OffsetHigh = (int)(offset >> 32);
            overlapped.OffsetLow = (int)offset;
            IOCompletionCallback callback =
                (errorCode, numBytes, nativeOverlapped) =>
                {
                    try
                    {
                        action();
                    }
                    finally
                    {
                        Overlapped.Free(nativeOverlapped);
                    }
                };
            NativeOverlapped* native = overlapped.Pack(callback, null);
            uint flags = exclusive ? LOCKFILE_EXCLUSIVE_LOCK : 0;
            if (!LockFileEx(handle, flags, 0, (int)length, (int)(length >> 32), native))
            {
                Overlapped.Free(native);
                WinIOError();
            }
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        private static unsafe extern bool LockFileEx(SafeFileHandle handle, uint flags, uint mustBeZero, int countLow, int countHigh, NativeOverlapped* overlapped);
