    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace StackOverflowQuestionWindowsService1
    {
        public partial class Service1 : ServiceBase
        {
            private ManualResetEvent stopEvent = new ManualResetEvent(false);
            private Task mainTask;
            private StreamWriter writer = File.CreateText(@"C:\Temp\Log.txt");     //TAKE CARE - I do not append anymore  ********
            private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            private int count = 0;
            
            public Service1()
            {
                InitializeComponent();
    
                writer.AutoFlush = true;
            }
    
            protected override void OnStart(string[] args)
            {
                Log("--------------");
                Log("OnStart");
    
                Task.Run(()=>Run());
            }
    
            protected override void OnStop()
            {
                Log("OnStop with actual thread count: " + Process.GetCurrentProcess().Threads.Count);
    
                cancellationTokenSource.Cancel();
            }
    
            private void Log(string line)
            {
                writer.WriteLine(String.Format("{0:yyyy-MM-dd HH:mm:ss.fff}: [{1,2}] {2}",
                    DateTime.Now, Thread.CurrentThread.ManagedThreadId, line));
            }
    
            private void Run()
            {
                Stopwatch stopWatchTotal = new Stopwatch();
                stopWatchTotal.Start();
    
                try
                {
                    using (var sha = SHA256.Create())
                    {
                        var parallelOptions = new ParallelOptions();
                        parallelOptions.MaxDegreeOfParallelism = -1;
                        parallelOptions.CancellationToken = cancellationTokenSource.Token;
                        parallelOptions.TaskScheduler = new PriorityScheduler(ThreadPriority.Lowest);
    
                        Parallel.ForEach(Directory.EnumerateFiles(Environment.SystemDirectory),
                            parallelOptions, (fileName, parallelLoopState) =>
                            {
                                // Thread.CurrentThread.Priority = ThreadPriority.Lowest;
                                Stopwatch stopWatch = new Stopwatch();
                                stopWatch.Start();
    
                                Interlocked.Increment(ref count);
    
                                if (parallelOptions.CancellationToken.IsCancellationRequested)
                                {
                                    Log(String.Format($"{count}"));
                                    return;
                                }
    
                                try
                                {
                                    var hash = sha.ComputeHash(File.ReadAllBytes(fileName).OrderBy(x => x).ToArray());
                                    stopWatch.Stop();
                                    Log(FormatTicks(stopWatch.ElapsedTicks));
                                    Log(String.Format($"{count}, {FormatTicks(stopWatch.ElapsedTicks)}, file={fileName}, sillyhash={Convert.ToBase64String(hash)}"));
                                }
                                catch (Exception ex)
                                {
                                    Log(String.Format($"{count} file={fileName}, exception={ex.Message}"));
                                }
                            });
                    }
                }
                catch (Exception ex)
                {
                    Log(String.Format("exception={0}", ex.Message));
                }
    
                stopWatchTotal.Stop();
    
                Log(FormatTicks(stopWatchTotal.ElapsedTicks));
    
                writer.Close();
                Process.GetCurrentProcess().Kill();
            }
    
            private string FormatTicks(long ticks)
            {
                return new TimeSpan(ticks).ToString();
            }
        }
    }
