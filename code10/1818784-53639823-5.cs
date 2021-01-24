    public sealed class MyThreadPool : IDisposable
    {
        private readonly Thread[] _threads;
        private readonly ConcurrentQueue<Action> _tasks = new ConcurrentQueue<Action>();
        private bool _enabled;
        private MyThreadPool(int count)
        {
            _enabled = true;
            _threads = new Thread[count];
            for (var i = 0; i < count; i++)
            {
                _threads[i] = new Thread(Consume);
                _threads[i].Start();
            }
        }
        public static void For(int threadCount, int from, int to, Action<int> action)
        {
            using (var pool = new MyThreadPool(threadCount))
            {
                for (int i = from; i < to; i++)
                {
                    var captured = i;
                    pool.EnqueueTask(() => action(captured));
                }
                pool.WaitTillCompletion();
            }
        }
        private void Consume()
        {
            while (_enabled)
            {
                Action task;
                if (_tasks.TryDequeue(out task))
                {
                    try
                    {
                        task();
                    }
                    catch
                    {
                        //can log error here if you want
                    }
                }
                else
                {
                    Thread.Sleep(0);
                }
            }
        }
        public void EnqueueTask(Action action)
        {
            _tasks.Enqueue(action);
        }
        public void WaitTillCompletion()
        {
            while (!_tasks.IsEmpty)
                Thread.Sleep(0);
        }
        public void Dispose()
        {
            _enabled = false;
            foreach (var t in _threads)
            {
                t.Join();
            }
        }
    }
