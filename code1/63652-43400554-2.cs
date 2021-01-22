    internal class ProcessManagement
    {
        private static int CpuPercentageLimit { get; set; }
        public static void StartProcess(int cpuPercent)
        {
            CpuPercentageLimit = cpuPercent;
            var stopwatch = new Stopwatch();
            while (true)
            {
                stopwatch.Reset();
                stopwatch.Start();
                var actionStart = stopwatch.ElapsedTicks;
                try
                {
                    var myProcess = new Process
                    {
                        StartInfo =
                        {
                            FileName = @"D:\\Source\\ExeProgram\\ExeProgram\\bin\\Debug\\ExeProgram.exe",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        }
                    };
                    myProcess.Start();
                    myProcess.PriorityClass = ProcessPriorityClass.Idle;
                    myProcess.Refresh();
                    myProcess.WaitForExit();
                    var actionEnd = stopwatch.ElapsedTicks;
                    var actionDuration = actionEnd - actionStart;
                    long relativeWaitTime = (int)((1 / (double)CpuPercentageLimit) * actionDuration);
                    var sleepTime = (int)((relativeWaitTime / (double)Stopwatch.Frequency) * 1000);
                    Thread.Sleep(sleepTime);
                    myProcess.Close();
                }
                catch (Exception e)
                {
                    // ignored
                }
            }
        }
    }
