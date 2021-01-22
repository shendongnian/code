        private void btnSleep_Click(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                Log.Info("Launching lengthy operation...");
                CursorWait.LengthyOperation(control, () => DummyAction());
                Log.Info("...Lengthy operation launched.");
            }
        }
        private void DummyAction()
        {
            try
            {
                var _log = NLog.LogManager.GetLogger("TmpLogger");
                _log.Info("Action - Sleep");
                TimeSpan sleep = new TimeSpan(0, 0, 16);
                Thread.Sleep(sleep);
                _log.Info("Action - Wakeup");
            }
            finally
            {
            }
        }
