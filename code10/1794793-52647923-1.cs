    public class WorkerHub {
        private readonly ConcurrentQueue<TaskWrapper> _tasks;
        private readonly Timer _timer;
        public WorkerHub() {
            _timer = new Timer();
            _tasks = new ConcurrentQueue<TaskWrapper>();
        }
        public Task<TResult> Post<TResult>(Func<TResult> func) {
            var cts = new TaskCompletionSource<TResult>();
            Action handler = () => {
                cts.SetResult(func());
            };
            var wrapper = new TaskWrapper { Invoke = handler };
            _tasks.Enqueue(wrapper);
            return cts.Task;
        }
        public Task Post(Action action) {
            var cts = new TaskCompletionSource<bool>();
            Action handler = () => {
                action();
                cts.SetResult(true);
            };
            var wrapper = new TaskWrapper { Invoke = handler };
            _tasks.Enqueue(wrapper);
            return cts.Task;
        }
        private TaskWrapper Pop()
        {
            _tasks.TryDequeue(out var wrapper);
            return wrapper;
        }
        public void Start() {
            _timer.Enabled = true;
            _timer.AutoReset = true;
            _timer.Interval = 2500;
            _timer.Elapsed += (sender, args) => {
                var wrapper = Pop();
                if (wrapper != null)
                    wrapper.Invoke();
            };
            _timer.Start();
        }
        public void Stop() {
        }
        private class TaskWrapper {
            public Action Invoke { get; set; }
        }
    }
