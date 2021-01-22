    public static class ProcessExtensions
    {
        public static async Task WaitForExitAsync(this Process process, CancellationToken cancellationToken = default)
        {
            var tcs = new TaskCompletionSource<bool>();
            void Process_Exited(object sender, EventArgs e)
            {
                 tcs.TrySetResult(true);
            }
            process.EnableRaisingEvents = true;
            process.Exited += Process_Exited;
            try
            {
                using (cancellationToken.Register(() => tcs.TrySetCanceled()))
                {
                    await tcs.Task;
                }
            }
            finally
            {
                process.Exited -= Process_Exited;
            }
        }
    }
