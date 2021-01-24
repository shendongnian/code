        private static readonly Stopwatch Stopwatch = new Stopwatch();
        private static TimeSpan _oldElapsed, _oldKernelTime, _oldUserTime;
        private static int ProcessorCount { get; }
        private static double _carryOver;
        static CpuUsage()
        {
            // Stopwatch will be used to track how much time/usage has elapsed.
            Stopwatch.Start();
            // We'll divide the total used CPU time by the number of processors.
            ProcessorCount = System.Environment.ProcessorCount;
            // Run to store the initial "oldKernel/UserTime" so the first read 
            // isn't super inflated by the application's start-up.
            GetTotalCpuTime();
        }
        /// <summary>
        /// Returns the average percentage of CPU time used since the last time this call was made.
        /// </summary>
        /// <returns></returns>
        private static TimeSpan GetTotalCpuTime()
        {
            // Because we could have more than one process running, add all of them up.
            var totalKernelTime = new TimeSpan();
            var totalUserTime = new TimeSpan();
            // Grab the diagnostic infos for all existing processes.
            var pdis = ProcessDiagnosticInfo.GetForProcesses();
            foreach (var pdi in pdis)
            {
                var cpuUsage = pdi.CpuUsage;
                var report = cpuUsage.GetReport();
                totalKernelTime += report.KernelTime;
                totalUserTime += report.UserTime;
            }
            // Subtract the amount of "Total CPU Time" that was previously calculated.
            var elapsedKernelTime = totalKernelTime - _oldKernelTime;
            var elapsedUserTime = totalUserTime - _oldUserTime;
            // Track the "old" variables.
            _oldKernelTime = totalKernelTime;
            _oldUserTime = totalUserTime;
            // Between both is all of the CPU time that's been consumed by the application.
            return elapsedKernelTime + elapsedUserTime;
        }
        public static double GetPercentage()
        {
            // Because there's a small amount of time between when the "elapsed" is grabbed, 
            // and all of the process KernelTime and UserTimes are tallied, the overall CPU
            // usage will be off by a fraction of a percent, but it's nominal.  Like in the 
            // 0.001% range.
            var elapsed = Stopwatch.Elapsed;
            var elapsedTime = elapsed - _oldElapsed;
            var elapsedCpuTime = GetTotalCpuTime();
            // Divide the result by the amount of time that's elapsed since the last check to 
            // get the percentage of CPU time that has been consumed by this application.
            var ret = elapsedCpuTime / elapsedTime / ProcessorCount * 100;
            // Track the "old" variables.
            _oldElapsed = elapsed;
            // This part is completely optional.  Because the thread could be called between 
            // the time that "elapsed" is grabbed, and the CPU times are calculated, this will
            // cause a "pause" that results in spiking the "CPU usage time" over 100%.  However
            // on the next call, the difference will be "lost" (so if it the CPU percent was
            // at 100% for two calls, but this 'pause' happened, one could report 150% while
            // the next would report 50%.)  By carrying over the values above 100%, we can get
            // a slightly more accurate "average" usage.  
            ret += _carryOver;
            if (ret > 100)
            {
                _carryOver = ret - 100;
                ret = 100;
            }
            else
            {
                _carryOver = 0;
            }
            return ret;
        }
