    public static class TaskExtensions
    {
        public static async Task<T> ExecuteAsyncOperation<T>(this Task<T> operation)
        {
            try
            {
                return await operation;
            }
            catch{ }
        }
    }
