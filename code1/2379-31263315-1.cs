        #region SyncContextCancel
        private SynchronizationContext _syncContextCancel;
        /// <summary>
        /// Gets the synchronization context used for UI-related operations.
        /// </summary>
        /// <value>The synchronization context.</value>
        protected SynchronizationContext SyncContextCancel
        {
            get { return _syncContextCancel; }
        }
        #endregion //SyncContextCancel
        public void CancelCurrentDbCommand()
        {
            _syncContextCancel = SynchronizationContext.Current;
            //ThreadPool.QueueUserWorkItem(CancelWork, null);
            Thread worker = new Thread(new ThreadStart(CancelWork));
            worker.Priority = ThreadPriority.Highest;
            worker.Start();
        }
        SQLiteConnection _connection;
        private void CancelWork()//object state
        {
            bool success = false;
            try
            {
                if (_connection != null)
                {
                    log.Debug("call cancel");
                    _connection.Cancel();
                    log.Debug("cancel complete");
                    _connection.Close();
                    log.Debug("close complete");
                    success = true;
                    log.Debug("long running query cancelled" + DateTime.Now.ToLongTimeString());
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
            SyncContextCancel.Send(CancelCompleted, new object[] { success });
        }
        public void CancelCompleted(object state)
        {
            object[] args = (object[])state;
            bool success = (bool)args[0];
            if (success)
            {
                log.Debug("long running query cancelled" + DateTime.Now.ToLongTimeString());
            }
        }
