    public class ActionRunner
    {
        public Action AttemptAction { get; set; }
        public Action SuccessfulAction { get; set; }
        public Action ExceptionAction { get; set; }
    
        public void RunAction()
        {
            try
            {
                AttemptAction();
                SuccessfulAction();
            }
            catch (Exception ex)
            {
                LogException(ex);
                ExceptionAction();
            }
        }
    
        private void LogException(Exception thrownException) { /* log here... */ }
    }
