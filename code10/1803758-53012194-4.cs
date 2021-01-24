    public static class Extensions
    {
        public static Task ExecuteAsync(this Process process)
        {
            var tcs = new TaskCompletionSource<bool>();
            process.Exited += (sender, eventArgs) =>
            {
                tcs.TrySetResult(true);
            };
            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }
            return tcs.Task;
        }
    }
