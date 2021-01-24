    public class ForceAwait
    {
        public Task<int> MethodAsync() => Task.FromResult(1);
        public Task Caller_Does_Not_Compile()
        {
            int result = MethodAsync();
            return Task.CompletedTask;
        }
        public async Task Caller_Compiles()
        {
            int result = await MethodAsync();
        }
    }
