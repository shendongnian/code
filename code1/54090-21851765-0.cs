        public class Timer : IDisposable
        {
            Logger logger = new Logger();
            Stopwatch stopWatch = new Stopwatch();
            public Timer()
            {
                calledFunc = CalledFunc;
                logger.LogInformation("Calling SomeObject.SomeMethod at " +
                    DateTime.Now.ToString());
                stopWatch.Start();
            }
            // Dispose() calls Dispose(true)
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            // NOTE: Leave out the finalizer altogether if this class doesn't 
            // own unmanaged resources itself, but leave the other methods
            // exactly as they are. 
            ~Timer()
            {
                // Finalizer calls Dispose(false)
                Dispose(false);
            }
            // The bulk of the clean-up code is implemented in Dispose(bool)
            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    // free managed resources
                    stopWatch.Stop();
                    logger.LogInformation("SomeObject.SomeMethod returned at " +
                        DateTime.Now.ToString());
                    logger.LogInformation("SomeObject.SomeMethod took " +
                        stopWatch.ElapsedMilliseconds + " milliseconds.");
                }
                // free native resources if there are any.
            }
        }
