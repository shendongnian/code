    public sealed class Test1 : Base
    {
        readonly Task _emptyTask;
        public Test1()
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
