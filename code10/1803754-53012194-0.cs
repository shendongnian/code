    public static class Extensions
    {
        public static Task ExecuteAsync(this Process process)
        {
            var tcs = new TaskCompletionSource<bool>();
            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }
            process.Exited += (sender, eventArgs) =>
            {
                tcs.TrySetResult(true);
            };
            return tcs.Task;
        }
    }
