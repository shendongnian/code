	using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace DailyWorker
    {
        class Program
        {
            static void Main(string[] args)
            {
                var cancellationSource = new CancellationTokenSource();
                var utils = new Utils();
                var task = Task.Run(
                    () => utils.DailyWorker(12, 30, 00, () => DoWork(cancellationSource.Token), cancellationSource.Token));
                Console.WriteLine("Hit [return] to close!");
                Console.ReadLine();
                cancellationSource.Cancel();
                task.Wait();
            }
            private static void DoWork(CancellationToken token)
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write(DateTime.Now.ToString("G"));
                    Console.CursorLeft = 0;
                    Task.Delay(1000).Wait();
                }
            }
        }
        public class Utils
        {
            public void DailyWorker(int hour, int min, int sec, Action someWork, CancellationToken token)
            {
                while (!token.IsCancellationRequested)
                {
                    var dateTimeNow = DateTime.Now;
                    var scanDateTime = new DateTime(
                        dateTimeNow.Year,
                        dateTimeNow.Month,
                        dateTimeNow.Day,
                        hour,       // <-- Hour when the method should be started.
                        min,  // <-- Minutes when the method should be started.
                        sec); // <-- Seconds when the method should be started.
                    TimeSpan ts;
                    if (scanDateTime > dateTimeNow)
                    {
                        ts = scanDateTime - dateTimeNow;
                    }
                    else
                    {
                        scanDateTime = scanDateTime.AddDays(1);
                        ts           = scanDateTime - dateTimeNow;
                    }
                    try
                    {
                         Task.Delay(ts).Wait(token);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    // Method to start
                    someWork();
                }
            }
        }
    }
