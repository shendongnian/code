    public class Algorithm1 : IAlgorithm
    {
        // asynchronous algorithm
        public async Task<int> ExecuteAsync() => await ...;
    }
    public class Algorithm2 : IAlgorithm
    {
        // synchronous algorithm
        public Task<int> ExecuteAsync()
        {
            int result = ...;
            return Task.FromResult(result);
        }
    }
