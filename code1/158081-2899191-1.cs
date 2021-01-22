    public class MySingletonClass
    {
        private bool continuePolling = true;
        public void Stop()
        {
            continuePolling = false;
        }
        public void Poll()
        {
            while (continuePolling)
            {
                // polling for messages here
            }
        }
    }
