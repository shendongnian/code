    class TrackedWorkers {
        class WorkerState {
            public object Input { get; private set; }
            public int ID { get; private set; }
            public Func<object, bool> Func { get; private set; }
            public WorkerState(Func<object, bool> func, object input, int id) {
                Func = func;
                Input = input;
                ID = id;
            }
        }
        AutoResetEvent[] events;
        bool[] statuses;
        bool _workComplete;
        int _number;
        public TrackedWorkers(int number) {
            if (number <= 0 || number > 64) {
                throw new ArgumentOutOfRangeException(
                    "number",
                    "number must be positive and at most 64"
                );
            }
            this._number = number;
            events = new AutoResetEvent[number];
            statuses = new bool[number];
            _workComplete = false;
        }
        void Initialize() {
            _workComplete = false;
            for (int i = 0; i < _number; i++) {
                events[i] = new AutoResetEvent(false);
                statuses[i] = true;
            }
        }
        void DoWork(object state) {
            WorkerState ws = (WorkerState)state;
            statuses[ws.ID] = ws.Func(ws.Input);
            events[ws.ID].Set();
        }
        public void LaunchWorkers(Func<object, bool> func, object[] inputs) {
            Initialize();
            for (int i = 0; i < _number; i++) {
                WorkerState ws = new WorkerState(func, inputs[i], i);
                ThreadPool.QueueUserWorkItem(this.DoWork, ws);
            }
            WaitHandle.WaitAll(events);
            _workComplete = true;
        }
        void ThrowIfWorkIsNotDone() {
            if (!_workComplete) {
                throw new InvalidOperationException("work not complete");
            }
        }
        public bool GetWorkerStatus(int i) {
            ThrowIfWorkIsNotDone();
            return statuses[i];
        }
        public IEnumerable<int> SuccessfulWorkers {
            get {
                return WorkersWhere(b => b);
            }
        }
        public IEnumerable<int> FailedWorkers {
            get {
                return WorkersWhere(b => !b);
            }
        }
        IEnumerable<int> WorkersWhere(Predicate<bool> predicate) {
            ThrowIfWorkIsNotDone();
            for (int i = 0; i < _number; i++) {
                if (predicate(statuses[i])) {
                    yield return i;
                }
            }
        }
    }
