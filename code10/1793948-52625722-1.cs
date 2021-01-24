    internal class Program
    {
        private static readonly object syncObj = new object();
        private static int lastNumerator;
        private static int numerator;
        private static int denominator;
        private static void ReportProgress()
        {
            int currentNumerator = numerator;
            // Don't emit progress if nothing changed
            if (currentNumerator == lastNumerator) return;
            Console.WriteLine($"{currentNumerator} of {denominator}");
            lastNumerator = currentNumerator;
        }
        private static void Main(string[] args)
        {
            MainAsync().Wait();
            Console.ReadLine();
        }
        private static async Task MainAsync()
        {
            // Setup example objects
            Random random = new Random();
            List<WorkObject> workObjects = new List<WorkObject>();
            int numberOfWorkObjects = random.Next(50, 100);
            for (int i = 0; i < numberOfWorkObjects; i++)
            {
                WorkObject workObject = new WorkObject(random);
                denominator += workObject.JobCount;
                workObjects.Add(workObject);
            }
            // The CancellationTokenSource is used to immediately abort the progress reporting once the work is complete
            CancellationTokenSource progressReportCancellationTokenSource = new CancellationTokenSource();
            Task workTask = Task.Run(() =>
                                     {
                                         Parallel.ForEach(workObjects,
                                                          wo =>
                                                          {
                                                              wo.PerformWork();
                                                              lock (syncObj)
                                                              {
                                                                  numerator += wo.JobCount;
                                                              }
                                                          });
                                         progressReportCancellationTokenSource.Cancel();
                                     });
            while (!workTask.IsCompleted)
            {
                try
                {
                    ReportProgress();
                    await Task.Delay(250, progressReportCancellationTokenSource.Token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
            }
            await workTask;
            ReportProgress();
        }
    }
