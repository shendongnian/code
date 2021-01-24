    public class WorkerHub {
        private readonly ConcurrentQueue<Action> _tasks;
        private readonly Timer _timer;
        public WorkerHub() {
            _timer = new Timer();
            _tasks = new ConcurrentQueue<Action>();
        }
        public Task<TResult> Post<TResult>(Func<TResult> func) {
            var cts = new TaskCompletionSource<TResult>();
            Action handler = () => {
                cts.SetResult(func());
            };
            _tasks.Enqueue(handler);
            return cts.Task;
        }
        public Task Post(Action action) {
            var cts = new TaskCompletionSource<bool>();
            Action handler = () => {
                action();
                cts.SetResult(true);
            };
            _tasks.Enqueue(handler);
            return cts.Task;
        }
        public void Start() {
            _timer.Enabled = true;
            _timer.AutoReset = true;
            _timer.Interval = 2500;
            _timer.Elapsed += (sender, args) => {
                Action handler = null;
                if (_tasks.TryDequeue(out  handler) && handler != null)
                    handler.Invoke();
            };
            _timer.Start();
        }
        public void Stop() {
        }
    }
