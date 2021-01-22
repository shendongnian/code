        static void MyFunction()
        {
            // Do other things...
            Schedule(1000, delegate
            {
                System.Diagnostics.Debug.WriteLine("Thanks for waiting");
            });
        }
        static void Schedule(int delayMs, Action action)
        {
    #if DONT_USE_THREADPOOL
            // If use of threadpool is undesired:
            new System.Threading.Thread(async () =>
            {
                await Task.Delay(delayMs);
                action();
            }
            ).Start(); // No need to store the thread object, just fire and forget
    #else
            // Using the threadpool:
            Task.Run(async delegate
            {
                await Task.Delay(delayMs);
                action();
            });
    #endif
        }
