        #region IDisposable Members
        private bool _isDisposed;
        private void ThrowIfDisposed()
        {
            if (_isDisposed)
                throw new ObjectDisposedException(this.GetType().Name);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    //part 1 : disposing managed objects
                    _command.Dispose();
                    _command.Connection.Dispose();
                    if (_command.Transaction != null)
                        _command.Transaction.Dispose();
                }
                //part 2: disposing unmanged objects. Here there are no unmanged objects.
                _isDisposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //~DbCommandExecutor() //No need of finalize here. Because there is no unmanged objects in my class. ie, no code in part 2.
        //{
        //    Dispose(false);
        //}
        #endregion
