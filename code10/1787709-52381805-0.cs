    public static class XXXExtensions
    {
        public static Task PostAsync(this XXX self, string requestUriString, string data)
        {
            var tcs = new TaskCompletionSource<bool>();
            self.Post(
               requestUriString,
               data,
               () => tcs.TrySetResult(true)
               () => tcs.TrySetException(new Exception()));
            return tcs.Task;
        }
    }
