	static class MessageResolver
    {
        #region Constructor
        static MessageResolver()
        {
            MessageHelper.Exception += OnException;
        }
        #endregion
        #region Events
        static void OnException(Exception e)
        {
            new ExceptionDialog(e).ShowDialog();
        }
        #endregion
    }
