    public static class ObexListenerExtensions
    {
        public static ObexListenerContext GetContext(this ObexListener listener, int timeout)
        {
            var task = Task.Run(async () => await listener.GetContextAsync(timeout));
            return task.Result;
        }
        public static async Task<ObexListenerContext> GetContextAsync(this ObexListener obexListener, int timeout)
        {
            var task = Task.Run(() => obexListener.GetContext());
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                return task.Result;
            }
            else
            {
                throw new TimeoutException();
            }
        }
    }
