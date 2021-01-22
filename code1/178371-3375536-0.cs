        int _taskResult;
        bool _taskFinished;
        /// <summary>Starts a background task to compute a value and returns immediately.</summary>
        void BeginTask()
        {
            _taskFinished = false;
            Task task = new Task(() =>
            {
                var result = LongComputation();
                lock (this)
                {
                    _taskResult = result;
                    _taskFinished = true;
                }
            });
            task.Start();
        }
        /// <summary>Performs the long computation. Called from within <see cref="BeginTask"/>.</summary>
        int LongComputation()
        {
            // Insert long computation code here
            return 47;
        }
