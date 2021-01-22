    class ActionDisposable: IDisposable
    {
        Action action;
        public ActionDisposable(Action action)
        {
            this.action = action;
        }
        #region IDisposable Members
        public void Dispose()
        {
            this.action();
        }
        #endregion
    }
