        /// <summary>
        /// Opens the specified reader writer lock in read mode,
        /// specifying whether or not it may be upgraded.
        /// </summary>
        /// <param name="slim"></param>
        /// <param name="upgradeable"></param>
        /// <returns></returns>
        public static IDisposable Read(this ReaderWriterLockSlim slim, bool upgradeable)
        {
            return new ReaderWriterLockSlimController(slim, true, upgradeable);
        } // IDisposable Read
        /// <summary>
        /// Opens the specified reader writer lock in read mode,
        /// and does not allow upgrading.
        /// </summary>
        /// <param name="slim"></param>
        /// <returns></returns>
        public static IDisposable Read(this ReaderWriterLockSlim slim)
        {
            return new ReaderWriterLockSlimController(slim, true, false);
        } // IDisposable Read
        /// <summary>
        /// Opens the specified reader writer lock in write mode.
        /// </summary>
        /// <param name="slim"></param>
        /// <returns></returns>
        public static IDisposable Write(this ReaderWriterLockSlim slim)
        {
            return new ReaderWriterLockSlimController(slim, false, false);
        } // IDisposable Write
        private class ReaderWriterLockSlimController : IDisposable
        {
            #region Fields
            private bool _closed = false;
            private bool _read = false;
            private ReaderWriterLockSlim _slim;
            private bool _upgrade = false;
            #endregion Fields
            #region Constructors
            public ReaderWriterLockSlimController(ReaderWriterLockSlim slim, bool read, bool upgrade)
            {
                _slim = slim;
                _read = read;
                _upgrade = upgrade;
                if (_read)
                {
                    if (upgrade)
                    {
                        _slim.EnterUpgradeableReadLock();
                    }
                    else
                    {
                        _slim.EnterReadLock();
                    }
                }
                else
                {
                    _slim.EnterWriteLock();
                }
            } //  ReaderWriterLockSlimController
            ~ReaderWriterLockSlimController()
            {
                Dispose();
            } //  ~ReaderWriterLockSlimController
            #endregion Constructors
            #region Methods
            public void Dispose()
            {
                if (_closed)
                    return;
                _closed = true;
                if (_read)
                {
                    if (_upgrade)
                    {
                        _slim.ExitUpgradeableReadLock();
                    }
                    else
                    {
                        _slim.ExitReadLock();
                    }
                }
                else
                {
                    _slim.ExitWriteLock();
                }
                GC.SuppressFinalize(this);
            } // void Dispose
            #endregion Methods
        } // Class ReaderWriterLockSlimController
