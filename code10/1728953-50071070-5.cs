    using System.Diagnostics;
    using System.Threading;
    public class HardFileStream : FileStream
    {
        [DebuggerHidden, DebuggerStepperBoundary]
        private static T Preconstructor<T>(T value, string path)
        {
            SpinWait.SpinUntil(delegate
            {
                try
                {
                    using (File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                    }
                }
                catch
                {
                    return false;
                }
                return true;
            });
            Thread.MemoryBarrier();
            return value;
        }
        [DebuggerHidden, DebuggerStepperBoundary]
        public HardFileStream(string path, FileMode mode)
            : base(Preconstructor(path, path), mode)
        {
        }
        [DebuggerHidden, DebuggerStepperBoundary]
        public HardFileStream(string path, FileMode mode, FileAccess access)
            : base(Preconstructor(path, path), mode, access)
        {
        }
        [DebuggerHidden, DebuggerStepperBoundary]
        public HardFileStream(string path, FileMode mode, FileAccess access, FileShare share)
            : base(Preconstructor(path, path), mode, access, share)
        {
        }
        [DebuggerHidden, DebuggerStepperBoundary]
        public HardFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize)
            : base(Preconstructor(path, path), mode, access, share, bufferSize)
        {
        }
        [DebuggerHidden, DebuggerStepperBoundary]
        public HardFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options)
            : base(Preconstructor(path, path), mode, access, share, bufferSize, options)
        {
        }
        [DebuggerHidden, DebuggerStepperBoundary]
        public HardFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync)
            : base(Preconstructor(path, path), mode, access, share, bufferSize, useAsync)
        {
        }
        [DebuggerHidden, DebuggerStepperBoundary]
        public HardFileStream(string path, FileMode mode, FileSystemRights rights, FileShare share, int bufferSize, FileOptions options)
            : base(Preconstructor(path, path), mode, rights, share, bufferSize, options)
        {
        }
        [DebuggerHidden, DebuggerStepperBoundary]
        public HardFileStream(string path, FileMode mode, FileSystemRights rights, FileShare share, int bufferSize, FileOptions options, FileSecurity fileSecurity)
            : base(Preconstructor(path, path), mode, rights, share, bufferSize, options, fileSecurity)
        {
        }
    }
