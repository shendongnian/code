        private void DoWork()
        {
            bool done = false;
            while (!done)
            {
                int job = _q.GetNextJob();
                if (job != Int32.MinValue)
                {
                    Console.WriteLine("Thread {0} Got job {1}", _i, job);
                    Thread.Sleep(job * 10); // in reality would to actual work here
                    if (JobFinished != null)
                        JobFinished(job);
                }
                else
                {
                    Console.WriteLine("Thread {0} no job available", _i);
                    done = true;
                }
            }
        }
