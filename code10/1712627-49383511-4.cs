    class Stopper
    {
        private readonly Updater _Updater;
        private Task _Task;
        public Stopper(Updater updater)
        {
            _Updater = updater;
            Run();
        }
        // Here's where we start yet another thread to listen to the console:
        private void Run()
        {
            // Start a new thread
            _Task = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (Console.ReadKey().Key.Equals(ConsoleKey.Enter))
                    {
                        _Updater.Stop();
                        return;
                    }
                }
            });
        }
        // This is the only public method!
        // It waits for the user to press enter in the console.
        public void Wait()
        {
            _Task.Wait();
        }
    }
