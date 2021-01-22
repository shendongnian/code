    public sealed class Test2 : Base
    {
        static readonly Task _emptyTask;
        static Test2()
        {
            TaskCompletionSource<Object> source = new TaskCompletionSource<object>();
            source.SetResult(null);
            _emptyTask = source.Task;
        }
        public override Task DoStuffAsync()
        {
            return _emptyTask;
        }
    }
