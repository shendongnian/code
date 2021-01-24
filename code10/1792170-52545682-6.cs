    public void ProcessFile()
    {
        ExceptionFilters.CatchFileExceptions( () => {
            // .. do your thing
        });
    }
    // somewhere else
    public static class ExceptionFilters
    {
        public static void CatchFileExceptions(Action action)
        {
            try
            {
                action();
            }
            catch(ExceptionTypeA aex)
            {
            }
            // ... and so on
            catch(Exception ex)
            {
            }
        }
    }
