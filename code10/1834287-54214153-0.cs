    public async Task<Result> Check(string name, Func<Task> execute)
    {
        try
        {
            await execute();
            return new Result(name, true, string.Empty);
        }
        catch (Exception ex)
        {
            return new Result(name, false, ex.Message);
        }
    }
    public class Result
    {
        public string Name { get; }
        public bool Success { get; }
        public string Message { get; }
        public Result(string name, bool success, string message) 
            => (Name, Success, Message) = (name, success, message);
    }
