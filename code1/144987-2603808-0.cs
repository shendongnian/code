    public static class Service<TProxy>
        where TProxy : ICommunicationObject, IDisposable, new()
    {
        public static void Using(Action<TProxy> action)
        {
            TProxy proxy = new TProxy();
            bool success = false;
            try
            {
                action(proxy);
                proxy.Close();
                success = true;
            }
            finally
            {
                if (!success)
                {
                    proxy.Abort();
                }
            }
        }
    }
