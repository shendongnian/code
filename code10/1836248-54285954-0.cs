    public static class ExceptionHandler
    {
        public static void HandleException(Exception e)
        {
        }
    }
    ...
    try
    {
    }
    catch (Exception e)
    {
        ExceptionHandler.HandleException(e);
    }
