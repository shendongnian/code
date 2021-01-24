    public class Worker
    {
        private Action _action;
        public event DoneHandler Done;
        // skipping defining DoneHandler delegate
        
        // store the action
        public Worker(Action action) => _action = action;
        public void Run()
        {
            // execute the action
            _action();
            // notify so that following code is run
            Done?.Invoke();
        }
    }
