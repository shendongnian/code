    public static class ExceptionHelper
    {
        public static void Wrap<TException>(Action action, Func<Exception, TException> exceptionCallback)
            where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw exceptionCallback(ex);
            }
        }
    }
    //Usage:
    ExceptionHelper.Wrap(() => this.Foo(), inner => new MyCustomException("Message", inner));
        
