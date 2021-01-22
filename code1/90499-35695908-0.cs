    class MyException : Exception
    {
        private const string AMP = "\r\nInnerException: ";
        public override string Message
        {
            get
            {
                return this.InnerException != null ? base.Message + AMP + this.InnerException.Message : base.Message;
            }
        }
        public override string StackTrace
        {
            get
            {
                return this.InnerException != null ? base.StackTrace + AMP + this.InnerException.StackTrace : base.StackTrace;
            }
        }
    }
