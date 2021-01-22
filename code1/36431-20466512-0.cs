    public static class CommunicationObjectExtensions
    {
        public static TResult MakeSafeServiceCall<TResult, TService>(this TService client, Func<TService, TResult> method) where TService : ICommunicationObject
        {
            TResult result;
            try
            {
                result = method(client);
            }
            finally
            {
                try
                {
                    client.Close();
                }
                catch (CommunicationException)
                {
                    client.Abort(); // Don't care about these exceptions. The call has completed anyway.
                }
                catch (TimeoutException)
                {
                    client.Abort(); // Don't care about these exceptions. The call has completed anyway.
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            return result;
        }
    }
