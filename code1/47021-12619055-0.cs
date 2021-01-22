    using System.Runtime.ExceptionServices;
    class Test
    {
        private ExceptionDispatchInfo _exInfo;
        public void DeleteNoThrow(string path)
        {
            try { File.Delete(path); }
            catch(IOException ex)
            {
                // Capture exception (including stack trace) for later rethrow.
                _exInfo = ExceptionDispatchInfo.Capture(ex);
            }
        }
        public Exception GetFailure()
        {
            // You can access the captured exception without rethrowing.
            return _exInfo != null ? _exInfo.SourceException : null;
        }
        public void ThrowIfFailed()
        {
            // This will rethrow the exception including the stack trace of the
            // original DeleteNoThrow call.
            _exInfo.Throw();
            // Contrast with 'throw GetFailure()' which rethrows the exception but
            // overwrites the stack trace to the current caller of ThrowIfFailed.
        }
    }
