    public class Wrapper
    {
        public static Exception TryCatch(Action actionToWrap, Action<Exception> exceptionHandler = null)
        {
            Exception retval = null;
            try
            {
                actionToWrap();
            }
            catch (Exception exception)
            {
                retval = exception;
                if (exceptionHandler != null)
                {
                    exceptionHandler(retval);
                }
            }
            return retval;
        }
        public static Exception LogOnError(Action actionToWrap, string errorMessage = "", Action<Exception> afterExceptionHandled = null)
        {
            return Wrapper.TryCatch(actionToWrap, (e) =>
            {
                if (afterExceptionHandled != null)
                {
                    afterExceptionHandled(e);
                }
            });
        }
    }
