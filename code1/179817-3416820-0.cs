            TimeSpan maxInterval = new TimeSpan(0, 10, 0);
            while(true)
            {
                DateTime startTime = DateTime.UtcNow;
                //Do lots and lots of work
                TimeSpan ts = DateTime.UtcNow - startTime;
                ts = (ts > maxInterval ? new TimeSpan(0) : maxInterval-ts);
                Thread.Sleep(ts);
            }
