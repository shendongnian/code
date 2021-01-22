    public static class MyExceptionManagement
    {
        public static bool LogException(Exception ex)
        {
            try
            {
                //try logging to a log source by priority, 
                //if it fails with all sources, return false as a last resort
                //we choose not to let logging issues interfere with user experience
                
                //if logging worked
                return true;
            }
            catch(Exception ex)
            {
                //in most cases, using try-catch as a true-false is bad practice
                //but when logging an exception causes an exception itself, we do
                //use this as a well-considered choice.
                return false;
            }
        }
    }
