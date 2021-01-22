    using System;
    using System.Threading;
    
    class Program
    {
        static void Main()
        {
            ReaderWriterLockSlim sync = new ReaderWriterLockSlim();
    
            using (sync.Read())
            {
               // etc    
            }
        }
    
    
    }
    public static class ReaderWriterExt
    {
        sealed class ReadLockToken : IDisposable
        {
            private ReaderWriterLockSlim sync;
            public ReadLockToken(ReaderWriterLockSlim sync)
            {
                this.sync = sync;
                sync.EnterReadLock();
            }
            public void Dispose()
            {
                if (sync != null)
                {
                    sync.ExitReadLock();
                    sync = null;
                }
            }
        }
        public static IDisposable Read(this ReaderWriterLockSlim obj)
        {
            return new ReadLockToken(obj);
        }
    }
