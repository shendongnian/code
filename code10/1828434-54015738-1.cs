    namespace Android.Runtime
    {
        public interface IJavaObject : IDisposable
        {
            IntPtr Handle { get; }
        }
    }
    namespace System
    {
        public interface IDisposable
        {
            void Dispose();
        }
    }
