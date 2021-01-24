    public class AsyncTesting
    {
        public void StartServiceTest()
        {
            Task<Task<int>> tsk1 = Task.Factory.StartNew(() => StartAsync());
            Task<int> tsk2 = Task.Factory.StartNew(() => StartAsync()).Unwrap();
            Task<int> tsk3 = Task.Factory.StartNew(async () => await StartAsync()).Unwrap();
        }
        public Task<int> StartAsync() => Task.Delay(2500).ContinueWith(tsk => 1);
    }
