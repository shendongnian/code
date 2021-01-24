    class Updater
    {
        // All messages sent to this object are stored in this concurrent queue
        private ConcurrentQueue<Action> _Actions = new ConcurrentQueue<Action>();
        private Task _Task;
        private bool _Running;
        private int _Counter = 0;
        // This is the constructor. It initializes the first element in the action queue,
        // and then starts the thread via the private Run method:
        public Updater()
        {
            _Running = true;
            _Actions.Enqueue(Print);
            Run();
        }
        private void Run()
        {
            _Task = Task.Factory.StartNew(() =>
            {
                // The while loop below quits when the private _Running flag
                // or if the queue of actions runs out.
                Action action;
                while (_Running && _Actions.TryDequeue(out action))
                {
                    action();
                }
            });
        }
        // Stop places an action on the event queue, so that when the Updater
        // gets to this action, the private flag is set.
        public void Stop()
        {
            _Actions.Enqueue(() => _Running = false);
        }
        // You can wait for the actor to exit gracefully...
        public void Wait()
        {
            if (_Running)
                _Task.Wait();
        }
        // Here's where the printing will happen. Notice that this method
        // puts itself unto the queue after the Sleep method returns.
        private void Print()
        {
            _Counter++;
            Console.WriteLine(string.Format("[{0}] Update #{1}",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _Counter));
            Thread.Sleep(1000);
            
            // Enqueue a new Print action so that the thread doesn't terminate
            if (_Running)
                _Actions.Enqueue(Print);
        }
    }
